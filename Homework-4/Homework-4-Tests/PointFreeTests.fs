module PointFreeTests

open FsCheck
open NUnit.Framework
open PointFree

let firstCheck x l = first_step x l = second_step x l

let secondCheck x l = second_step x l = third_step x l

let thirdCheck x l = third_step x l = fourth_step x l

[<Test>]
let first_test () = Check.QuickThrowOnFailure firstCheck

[<Test>]
let second_test () = Check.QuickThrowOnFailure secondCheck

[<Test>]
let third_test () = Check.QuickThrowOnFailure thirdCheck
