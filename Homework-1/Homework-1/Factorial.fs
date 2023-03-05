module Homework_1.Factorial

/// <summary>
/// Factorial function
/// </summary>
/// <param name="n">Number</param>
/// <returns>n! if n >= 0 else None</returns>
let factorial n =
    if n < 0 then
        None
    else
        let rec fac n acc =
            match n with
            | 0
            | 1 -> acc
            | _ -> fac (n - 1) acc * n

        Some(fac n 1)
