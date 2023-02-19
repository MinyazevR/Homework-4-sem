module Homework_1.Factorial

/// <summary>
/// Factorial function
/// </summary>
/// <param name="n">Number</param>
/// <returns>n! if n >= 0 else 0</returns>
let rec factorial n =
    if n < 0 then 0 else
    match n with
    | 0 | 1 -> 1
    | _ -> n * factorial (n - 1)