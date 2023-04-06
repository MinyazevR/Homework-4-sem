module Homework_4.TelephoneDirectory

type Result =
    | Success of seq<string>
    | Error of seq<string>

/// <summary>
/// Telephone Directory
/// </summary>
type TelephoneDirectory(entries: seq<string * string>) =
    let listOfEntries = entries
    new() = TelephoneDirectory Seq.empty

    member this.Entries
        with get() = listOfEntries

    member this.Add name number =
        TelephoneDirectory(Seq.append listOfEntries (Seq.singleton (name, number)))


    member this.FindPhoneByName name =
        let ans =
            seq {
                for x, _ in listOfEntries do
                    if x = name then
                        x
            }

        if ans |> Seq.isEmpty then
            Error [ "Name not found" ]
        else
            Success ans


    member this.FindNameByPhone phone =
        let ans =
            seq {
                for _, y in listOfEntries do
                    if y = phone then
                        y
            }

        if ans |> Seq.isEmpty then
            Error [ "Phone not found" ]
        else
            Success ans

    member this.OutputEntries =
        for x, y in listOfEntries do
            printf $"Name: {x}, Number: {y}\n"

    member this.SaveDataToFile path =
        use writer = new System.IO.StreamWriter(path, false)

        for x, y in listOfEntries do
            writer.WriteLine $"Name: {x}, Number: {y}"

    member this.ReadDataFromFile(path: string) =
        TelephoneDirectory(
            seq {
                use reader = new System.IO.StreamReader(path, false)

                while not reader.EndOfStream do
                    let x = reader.ReadLine().Split(" ")
                    yield (x[0], x[1])
            }
        )
        