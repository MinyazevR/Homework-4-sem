module Homework_1.Fibonacci

/// <summary>
/// Function for calculating the nth Fibonacci number
/// </summary>
/// <param name="n">Number</param>
/// <returns> Nth fibonacci number if n >= 0 else None </returns>
let fibonacci n =
    if n < 0 then None else
    let rec fib n iter (a, b) =
        if iter < n then fib n (iter + 1) (b, a + b)
        else b
    if n = 0 then Some 0 else Some (fib n 1 (0, 1))

