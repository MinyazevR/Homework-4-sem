module Homework_4.TelephoneDirectoryInputOutput

open TelephoneDirectory

/// <summary>
/// Function for output of records to the console
/// </summary>
/// <param name="directory">Directory</param>
let OutputEntries (directory: TelephoneDirectory) =
    for x, y in directory.Entries do
        printf $"Name: {x}, Number: {y}\n"

/// <summary>
/// Function for saving data to a file
/// </summary>
/// <param name="directory">Directory</param>
/// <param name="path">Path to file</param>
let SaveDataToFile (directory: TelephoneDirectory) path =
    use writer = new System.IO.StreamWriter(path, false)

    for x, y in directory.Entries do
        writer.WriteLine $"{x} {y}"

/// <summary>
/// Function for reading data from a file
/// </summary>
/// <param name="directory">Directory</param>
/// <param name="path">Path to file</param>
let ReadDataFromFile (directory: TelephoneDirectory) (path: string) =
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
