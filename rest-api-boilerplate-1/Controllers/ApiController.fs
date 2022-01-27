namespace rest_api_boilerplate_1
namespace rest_api_boilerplate_1.Controllers


open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging


type User = {
  Name: string 
  Age: int
}

[<ApiController>]
[<Route("[controller]")>]
type ApiController (logger : ILogger<ApiController>) =
    inherit ControllerBase()

    [<Route("id/{name}")>]
    [<HttpGet>]
    member _.Get(name: string) =
      logger.LogInformation $"{name}"

      // let myUser = None

      let myUser = {
        Name = name
        Age = 40
      }

      ActionResult<User>(myUser)

