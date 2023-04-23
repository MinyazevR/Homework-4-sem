module Homework_6_Tests.RoundingWorkflowTest

open NUnit.Framework
open FsUnit
open Homework_6.RoundingWorkflow

let testCaseData =
    [ 3, 0.048; 1, 0.1; 0, 0.0 ] |> List.map (fun (x, y) -> TestCaseData(x, y))

[<TestCaseSource("testCaseData")>]
let first_test (accuracy, expected: float) =
    Builder(accuracy) {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    |> should equal expected


[<Test>]
let fourth_test () =
    (fun () ->
        Builder(-3) {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
        |> ignore)
    |> should throw typeof<System.ArgumentOutOfRangeException>
