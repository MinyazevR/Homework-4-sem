module Homework_1.SeriesOfDegree

/// <summary>
/// Function for getting a list of degrees 2
/// </summary>
/// <param name="n">Indicator of the first degree</param>
/// <param name="m">Indicator of the last degree</param>
/// <returns>Returns a list of powers of 2 from n to n + m</returns>
let seriesOfDegree n m =
    let upper_bound = 2.0 ** (n + m)

    2.0 ** n
    |> List.unfold (fun state ->
        if state > upper_bound then
            None
        else
            Some(state, state * 2.0))
