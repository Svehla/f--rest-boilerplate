#!/usr/bin/env dotnet fsi

open System.IO
open System.Collections


// --------------------------------
// how .net ecosystem is working 

// --------------------------------
// funcitonal vs OOP language

// > language-comparision image 

(*
support:
  -for cycles,
  -instances,
  -recursions,
  -mutable data structures,
  -immutable data structures and so on...
*)

// variables --------------------------------

printfn $"ahoj {3+3}"

let val1 = 4.0
// C:
// float val1 = 4.0

let val2 = 3.0

let val3 = val1 + val2

(*

private class Constants {
  readonly public static float val1 = 4.0
  readonly public static float val2 = 3.0
}

class main {
  static void Main() {
    // float result = Constants.val1 + Constants.val2

    // > never C# code
    // let result = Constants.val1 + Constants.val2
  }
}

*)


// functions -> hidlney milner algorithms --------------------------------


(* C#

private class Math {
  public static float sum (float a, float b) {
    return a + b
  }
}

class main {
  static void Main() {
    // float result = Math.sum(Constants.val1, Constants.val2)

    // > never C# code
    // let result = Math.sum(Constants.val1, Constants.val2)
  }
}

*)

(* ts

const sum = (a: number, b: number): number => a + b

// inferred returned value
const sum = (a: number, b: number) => a + b

*)


let sum1 (a: float) (b: float): float = a + b

let sum2 a b = a + b



let sum3 a b: float = a + b

let res = sum2 2 2

// --------------------------------
// data structures (nominal vs structural) 

type User = {
  Id: string
  Name: string
}

type Account = {
  Id: string
  Value: float
  UserId: string
}


let user1 = {
  Id = "UUID-1"
  Name = "Kuba"
}

let account1 = {
  Id = "AC-UUID-1"
  Value = 3.0
  UserId = user1.Id
}


let getAccountValue account = account.Value

// --------------------------------
// iterating over lists + lambda functions (anonymous) + touples


let myList1 = [1; 2; 3; 4; 5; 6]



let myList2 = 
  myList1
    |> List.map (fun i -> (i, i * 2))
    // |> fun i -> printf $"{i}"


printfn "----------"
printfn $"{myList2}"



// union + pattern matching --------------------

let pi = 3.141592654

type Shape =
  | Circle of float
  | EquilateralTriangle of double
  | Square of double
  | Rectangle of double * double // [a, b] === (a * b) === a * b


let area myShape =
  match myShape with
  | Circle radius -> pi * radius * radius
  | EquilateralTriangle s -> (sqrt 3.0) / 4.0 * s * s
  | Square s -> s * s
  | Rectangle (h, w) -> h * w

// dependency injection? => pass function into arguments + curried functions


// compile F# into JS by fable 

