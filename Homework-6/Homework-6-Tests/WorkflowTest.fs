module Homework_6_Tests.WorkflowTest

open NUnit.Framework
open FsUnit
open Homework_6.Workflow

[<Test>]
let testForValidData () =
    let calculate = Builder()

    let result =
        calculate {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }

    result |> should equal (Some 3)

[<Test>]
let testForInValidData () =
    let calculate = Builder()

    let result =
        calculate {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
        }

    result |> should equal None
