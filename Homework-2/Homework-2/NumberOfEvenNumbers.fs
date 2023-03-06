module Homework_2.NumberOfEvenNumbers

/// <summary>
/// Function for counting even list items using map
/// </summary>
let numberOfEvenNumbersWithMap =
    List.map (fun x -> if x % 2 = 0 then 1 else 0) >> List.sum

/// <summary>
/// Function for counting even list items using filter
/// </summary>
let numberOfEvenNumbersWithFilter = List.filter (fun x -> x % 2 = 0) >> List.length

/// <summary>
/// Function for counting even list items using fold
/// </summary>
let numberOfEvenNumbersWithFold =
    List.fold (fun s v -> if v % 2 = 0 then s + 1 else s) 0
