module PointFreeTests

open FsCheck
open PointFree
open FsUnit

let firstCheck x l =
    first_step x l = second_step x l
    
let secondCheck x l =
    second_step x l = third_step x l
    
let thirdCheck x l =
    third_step x l = fourth_step x l
    
Check.QuickThrowOnFailure firstCheck
Check.QuickThrowOnFailure secondCheck
Check.QuickThrowOnFailure thirdCheck