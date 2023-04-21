module Tests

open NUnit.Framework
open Program
open FsUnit


[<Test>]
let TestRhomb () =
    rhomb 2 |> should equal " *\n***\n *\n"
    rhomb 4 |> should equal "   *\n  ***\n *****\n*******\n *****\n  ***\n   *\n"
    

