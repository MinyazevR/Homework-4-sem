module Homework_1.SeriesOfDegree

/// <summary>
/// Function for getting a list of degrees 2
/// </summary>
/// <param name="n">Indicator of the first degree</param>
/// <param name="m">Indicator of the last degree</param>
/// <returns>Returns a list of powers of 2 from n to n + m</returns>
let seriesOfDegree n m = [ for i in n .. n + m -> 2. ** i ]