namespace rest_api_boilerplate_1
namespace rest_api_boilerplate_1.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

open Npgsql.FSharp

type FruitId = {
  Id: int
}

type Fruit = {
  Id: int
  Name: string
}


type NewFruitData = {
  Name : string
}

module DbConfig = 
  // TODO: extract connections to the environment variables
  let connectionString = "postgres://root:root@localhost:5432/fs_node_boilerplate_local"

module Fruits = 

  let dbConnection = 
    DbConfig.connectionString |> Sql.connect
  
  let mapRowToFruit (read: RowReader) = {
    Id = read.int "id"
    Name = read.text "name"
  }

  let getById (id: int) =
    let fruits =
      dbConnection
        |> Sql.query "SELECT * FROM fruits where id = @id"
        |> Sql.parameters [("id", Sql.int id )]
        |> Sql.execute mapRowToFruit

    List.head fruits

  let getAll () =
    dbConnection
    |> Sql.query "SELECT * FROM fruits ORDER BY id DESC"
    |> Sql.execute mapRowToFruit

  let create (name: string) = 
    let newFruitId = 
      dbConnection
        |> Sql.query "INSERT INTO fruits(name) VALUES(@name) RETURNING id;" 
        |> Sql.parameters [("name", Sql.string name )]
        |> Sql.execute (fun read -> { Id = read.int "id" })

    getById (List.head newFruitId).Id

  let update (fruit: Fruit) = 
    dbConnection
      |> Sql.query "UPDATE public.fruits SET name=@name WHERE id=@id;" 
      |> Sql.parameters [("name", Sql.string fruit.Name); ("id", Sql.int fruit.Id)]
      |> Sql.execute mapRowToFruit
      |> ignore

    getById fruit.Id


[<ApiController>]
[<Route("[controller]")>]
type ApiController (logger : ILogger<ApiController>) =

    inherit ControllerBase()

    [<Route("fruits")>]
    [<HttpPost>]
    member _.CreateFruit(data: NewFruitData) =
      let newfruit = Fruits.create(data.Name)
      ActionResult<Fruit>(newfruit)

    [<Route("fruits")>]
    [<HttpPut>]
    member _.UpdateFruit fruit =
      let updatedFruit = Fruits.update(fruit)
      ActionResult<Fruit>(updatedFruit)

    [<Route("fruits")>]
    [<HttpGet>]
    member _.Fruits() =
      ActionResult<Fruit list>(Fruits.getAll())

    [<Route("fruits/{id}")>]
    [<HttpGet>]
    member _.Get(id: string) =

      ActionResult<Fruit>(Fruits.getById (int id))

