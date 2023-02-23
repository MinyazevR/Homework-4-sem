module Homework_1.ReverseList

/// <summary>
/// Function to reverse the list
/// </summary>
/// <param name="list">The input list.</param>
/// <returns>Returns a new list with the elements in reverse order.</returns>
let rev list =
    let rec reverse list answer =
        match list with
        | head :: tail -> reverse tail (head :: answer)
        | _ -> answer

    reverse list []
