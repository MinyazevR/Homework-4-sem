module Homework_1.SeriesOfDegree

/// <summary>
/// Function for getting a list of degrees 2
/// </summary>
/// <param name="n">Indicator of the first degree</param>
/// <param name="m">Indicator of the last degree</param>
/// <returns>Returns a list of powers of 2 from n to n + m</returns>
let seriesOfDegree n m =
    let rec multiplyLastElemOn2 ls count iter state =
        if iter < count then multiplyLastElemOn2 (List.append ls [state * 2.0]) count (iter + 1) (state * 2.0)
        else ls
    let answer = [2.0 ** n]
    multiplyLastElemOn2 answer m 0 answer.Head