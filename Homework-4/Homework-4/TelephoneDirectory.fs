module Homework_4.TelephoneDirectory

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

        if ans |> Set.isEmpty then None else Some ans


    /// <summary>
    /// Method for finding a number by phone
    /// </summary>
    /// <param name="phone"> Phone</param>
    /// <returns> Result type from set of names</returns>
    member this.FindNameByPhone phone =
        let ans = Set.filter (fun (_, y) -> y = phone) listOfEntries |> Set.map fst

        if ans |> Set.isEmpty then None else Some ans
