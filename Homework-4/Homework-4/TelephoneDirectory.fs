module Homework_4.TelephoneDirectory

type Result =
    | Success of Set<string>
    | Error of Set<string>

/// <summary>
/// Telephone Directory
/// </summary>
type TelephoneDirectory(entries: Set<string * string>) =
    let listOfEntries = entries
    new() = TelephoneDirectory Set.empty

    member this.Entries = listOfEntries

    /// <summary>
    /// Method for adding an entry to the phone directory
    /// </summary>
    /// <param name="name"> Name</param>
    /// <param name="number"> Number</param>
    /// <returns>If there was no entry, this is a new phone directory with an added entry, otherwise it will return the original phone directory</returns>
    member this.Add name number =
        if Set.contains (name, number) listOfEntries then
            this
        else
            TelephoneDirectory(Set.add (name, number) listOfEntries)


    /// <summary>
    /// Method for finding a phone by number
    /// </summary>
    /// <param name="name"> Name</param>
    /// <returns> Result type from set of phones</returns>
    member this.FindPhoneByName name =
        let ans = Set.filter (fun (x, _) -> x = name) listOfEntries |> Set.map snd

        if ans |> Set.isEmpty then
            Error(Set.add "Name not found" Set.empty)
        else
            Success ans


    /// <summary>
    /// Method for finding a number by phone
    /// </summary>
    /// <param name="phone"> Phone</param>
    /// <returns> Result type from set of names</returns>
    member this.FindNameByPhone phone =
        let ans = Set.filter (fun (_, y) -> y = phone) listOfEntries |> Set.map fst

        if ans |> Set.isEmpty then
            Error(Set.add "Phone not found" Set.empty)
        else
            Success ans

    /// <summary>
    /// Function for output of records to the console
    /// </summary>
    member this.OutputEntries =
        for x, y in listOfEntries do
            printf $"Name: {x}, Number: {y}\n"

    /// <summary>
    /// Function for saving data to a file
    /// </summary>
    /// <param name="path"> Path to file</param>
    member this.SaveDataToFile path =
        use writer = new System.IO.StreamWriter(path, false)

        for x, y in listOfEntries do
            writer.WriteLine $"{x} {y}"

    /// <summary>
    /// Function for reading data from a file
    /// </summary>
    /// <param name="path"> Path to file</param>
    member this.ReadDataFromFile(path: string) =
        TelephoneDirectory(
            Set.ofSeq (
                seq {
                    use reader = new System.IO.StreamReader(path, false)

                    while not reader.EndOfStream do
                        let x = reader.ReadLine().Split(" ")
                        yield (x[0], x[1])
                }
            )
        )
