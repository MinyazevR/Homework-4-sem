module LambdaInterpreterTests

open NUnit.Framework
open FsUnit
open LambdaInterpreter

// (λx.y) ((λx. x x x) (λx. x x x)) -> y
[<Test>]
let first_example () =
    let answer =
        beta_reduce (
            Application(
                Abstraction("x", Variable "y"),
                Application(
                    Abstraction("x", Application(Variable "x", Application(Variable "x", Variable "x"))),
                    Abstraction("x", Application(Variable "x", Application(Variable "x", Variable "x")))
                )
            )
        )

    answer |> should equal (Variable "y")

// (λx.x) (λx. x) -> (λx. x)
[<Test>]
let second_example () =
    let answer =
        beta_reduce (Application(Abstraction("x", Variable "x"), Abstraction("x", Variable "x")))

    answer |> should equal (Abstraction("x", Variable "x"))

// (λx.λy.x)(λx.x) → λy.(λx.x)
[<Test>]
let third_example () =
    let answer =
        beta_reduce (Application(Abstraction("x", Abstraction("y", Variable "x")), Abstraction("x", Variable "x")))

    answer |> should equal (Abstraction("y", Abstraction("x", Variable "x")))
