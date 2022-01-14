namespace rest_api_boilerplate_1.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open rest_api_boilerplate_1


[<ApiController>]
[<Route("api")>]
type XdController () =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Z() =
      let values = [|"root"|]
      ActionResult<string[]>(values)

    [<HttpGet("ahoj")>]
    member _.Y() =
      let values = [|"ahoj"|]
      ActionResult<string[]>(values)

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>) =
    inherit ControllerBase()
    let summaries =
        [|
            "Freezing"
            "Bracing"
            "Chilly"
            "Cool"
            "Mild"
            "Warm"
            "Balmy"
            "Hot"
            "Sweltering"
            "Scorching"
        |]

    [<HttpGet>]
    member _.Get() =
      let values = [|"Hello"; "World"; "First F#/ASP.NET Core web API!"|]
      ActionResult<string[]>(values)



module MyMeasures = 
    [<Measure>] type m
    [<Measure>] type sec
    [<Measure>] type kg

    let distance = 1.0<m>
    let time = 2.0<sec>
    let speed = distance/time
    let acceleration = speed/time
    let mass = 5.0<kg>
    let force = mass * speed/time



