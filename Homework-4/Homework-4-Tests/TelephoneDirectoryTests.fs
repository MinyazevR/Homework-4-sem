module Homework_4_Tests.TelephoneDirectoryTests

open Homework_4
open NUnit.Framework
open FsUnit
open TelephoneDirectory

[<Test>]
let AddRecordsTests () =
    let directory = TelephoneDirectory()
    let second_directory = directory.Add "Махмур" "12345678"

    second_directory.Entries
    |> should equal (Set.ofSeq (seq { ("Махмур", "12345678") }))

    let third_directory = second_directory.Add "Сергей" "809543683"

    third_directory.Entries
    |> should
        equal
        (Set.ofSeq (
            seq {
                ("Махмур", "12345678")
                ("Сергей", "809543683")
            }
        ))

[<Test>]
let AddIdenticalRecordsTest () =
    let directory = TelephoneDirectory()
    let second_directory = directory.Add "Махмур" "12345678"

    second_directory.Entries
    |> should equal (Set.ofSeq (seq { ("Махмур", "12345678") }))

    let third_directory = second_directory.Add "Махмур" "12345678"
    (third_directory = second_directory) |> should equal true

    third_directory.Entries
    |> should equal (Set.ofSeq (seq { ("Махмур", "12345678") }))

[<Test>]
let SuccessFindPhoneByName () =
    let directory = TelephoneDirectory()
    let second_directory = directory.Add "Махмур" "12345678"

    second_directory.FindPhoneByName "Махмур"
    |> should equal (Some(Set.add "12345678" Set.empty))

    let third_directory = second_directory.Add "Махмур" "87654321"

    third_directory.FindPhoneByName "Махмур"
    |> should
        equal
        (Some(
            Set.ofSeq (
                seq {
                    "12345678"
                    "87654321"
                }
            )
        ))


[<Test>]
let ErrorFindPhoneByName () =
    let directory = TelephoneDirectory()
    let second_directory = directory.Add "Махмур" "12345678"

    second_directory.FindPhoneByName "Махма" |> should equal None

[<Test>]
let SuccessFindNameByPhone () =
    let directory = TelephoneDirectory()
    let second_directory = directory.Add "Махмур" "12345678"

    second_directory.FindNameByPhone "12345678"
    |> should equal (Some(Set.add "Махмур" Set.empty))

    let third_directory = second_directory.Add "Брат махмура" "12345678"

    third_directory.FindNameByPhone "12345678"
    |> should
        equal
        (Some(
            Set.ofSeq (
                seq {
                    "Махмур"
                    "Брат махмура"
                }
            )
        ))


[<Test>]
let ErrorFindNameByPhone () =
    let directory = TelephoneDirectory()
    let second_directory = directory.Add "Махмур" "12345678"

    second_directory.FindNameByPhone "12345679" |> should equal None
