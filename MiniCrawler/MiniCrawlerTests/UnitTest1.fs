module MiniCrawlerTests

open NUnit.Framework
open MiniCrawler
open FsUnit

[<Test>]
let firstMiniCrawlerTest () =
    let answer =  work "https://github.com/PrettyBoyCosmo/HTTP-List"
    answer |> Seq.contains (57641, "http://www.socialstudieshelp.com/") |> should equal true
    answer |> Seq.contains (12283, "http://targetedattacks.trendmicro.com/") |> should equal true
    answer |> Seq.contains (200480, "http://blog.adw.org") |> should equal true
    answer |> Seq.contains (118102, "http://www.hexun.com/") |> should equal true
    answer |> Seq.contains (1930, "http://www.sneachennai.com/") |> should equal true
    