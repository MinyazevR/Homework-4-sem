module Homework_4.TelephoneDirectoryProgram

open TelephoneDirectory
open TelephoneDirectoryInputOutput
open System
open Argu

type CliError = | ArgumentsNotSpecified

type CmdArgs =
    | Exit
    | Add of name: string * number: string
    | FindName of number: string
    | FindPhone of name: string
    | Output
    | SaveData of path: string
    | ReadData of path: string

    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Exit -> "Exit"
            | Add _ -> "Add entry to the phone directory"
            | Output -> "Output entries"
            | SaveData _ -> "Save data to file"
            | ReadData _ -> "Read data from file"
            | FindName _ -> "Find name by phone"
            | FindPhone _ -> "Find phone by name"


let main () =
    let errorHandler =
        ProcessExiter(
            colorizer =
                function
                | ErrorCode.HelpText -> None
                | _ -> Some ConsoleColor.Red
        )

    let parser =
        ArgumentParser.Create<CmdArgs>(programName = "TelephoneDirectory", errorHandler = errorHandler)

    let rec a (directory: TelephoneDirectory) =
        match parser.ParseCommandLine(inputs = Console.ReadLine().Split(" ")) with
        | parser when parser.Contains(Output) ->
            OutputEntries directory
            a directory
        | parser when parser.Contains(Add) ->
            let name, number = parser.GetResult Add
            printf "Entry was added"
            a (directory.Add name number)
        | parser when parser.Contains(FindName) ->
            let number = parser.GetResult FindName
            let answer = directory.FindNameByPhone number

            match answer with
            | None -> printf "phone not found"
            | Some _ ->
                for x in seq { answer } do
                    printf $"name: {x}, number: {number}"

            a directory
        | parser when parser.Contains(FindPhone) ->
            let name = parser.GetResult FindPhone
            let answer = directory.FindNameByPhone name

            match answer with
            | None -> printf "name not found"
            | Some _ ->
                for x in seq { answer } do
                    printf $"name: {name}, number: {x}"

            a directory
        | parser when parser.Contains(SaveData) ->
            let path = parser.GetResult SaveData
            SaveDataToFile directory path
            printf "Directory has been saved"
            a directory
        | parser when parser.Contains(ReadData) ->
            let path = parser.GetResult ReadData
            printf "Directory has been read"
            a (ReadDataFromFile directory path)
        | parser when parser.Contains(Exit) -> Ok Exit
        | _ -> Error Exit

    match (a (TelephoneDirectory())) with
    | Ok Exit -> "The program was successfully completed"
    | _ -> "The program terminated with an error"

printf $"{main ()}"
