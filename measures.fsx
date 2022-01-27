#!/usr/bin/env dotnet fsi

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

  let sumTNums (a, b, c) = a + b + c

  let sumNums a b c = a + b + c


  let where filter customers =
    seq {
      for customer in customers do
        if filter customer then
          yield customer }

  type Customer = { Age : int }

  type FakeCustomer = { 
    Age : int
    Name: char
  }

  let fakeCustomers = [ { Age = 21; Name = 'x' } ]
  let customers = [ { Age = 21 }; { Age = 35 }; { Age = 36 } ]


  let isOver35 (c: Customer) = c.Age > 35

  customers 
    |> where isOver35 
    |> ignore

  customers 
    |> where (fun c -> c.Age > 35) 
    |> ignore





