#!/usr/bin/env dotnet fsi

open System.IO
open System.Collections

let writeToFile text = File.WriteAllText(@"C:\temp\output.txt", text)

let addX s = $"{s}x"

let text = "Hello world" |> addX

printfn $"1 + 1 = {1 + 1} {text}"

let sum a b: float = a + b



type WeatherForecast =
  { Date: string
    TemperatureC: int
    Summary: string }

  member this.TemperatureF =
      32.0 + (float this.TemperatureC / 0.5556)

type Customer = 
  { Id: string
    Name: string
    Price: int }

  member _.getId = 3


type User = 
  { Id: string
    Name: string }

let kuba = {
  Id = "01"
  Name = "Kuba"
}


let myFn arg = arg.Id

// let getId nejakej = nejakej.getId

// let xd = getId kuba



let toArray value = [value]


let val1 = toArray 1

let val2 = toArray 'a'

let val3 = toArray 3.0

let doubleData = List.map (fun i -> i * 2.0) [1.0]


let create id n = {
  Id = id
  Name = n
}
  
let data = [
  create "001" "Kuba"
  create "002" "Luke"
  create "003" "Jan"
  create "004" "Kuba"
]

let getGrouped (d: list<User>) = 
  d
    |> List.groupBy (fun i -> i.Name)
    |> List.map (fun (name, arr) -> arr)
    |> List.map List.length
    |> List.sum

let grouped = getGrouped data

// grouped
//   |> List.iter (fun x -> printf $"{x}\n")

printfn $"{grouped}"

let xxx = 
  [2 .. 5]
    |> List.pairwise
    |> List.map (fun i -> printfn $"{i}")
    |> List.toSeq

printfn $"xxx: {xxx}"


let inventory =
                  [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.45 ]
                  |> dict

let bananas = inventory.["Bananas"]

let inventory2 =
     [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.45 ]
     |> Map.ofList

let apples = inventory.["Apples"]
let pineapples = inventory.["Pineapples"]
let newInventory =
  inventory2
    |> Map.add "Pineapples" 0.87
    |> Map.remove "Apples"