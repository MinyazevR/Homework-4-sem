module MiniCrawlerTests

open NUnit.Framework
open MiniCrawler
open FsUnit

[<Test>]
let firstMiniCrawlerTest () =
    let answer = work "https://github.com/PrettyBoyCosmo/HTTP-List"
    let http = answer |> Seq.map snd
    
    http
    |> Seq.contains "http://www.socialstudieshelp.com/"
    |> should equal true

    http
    |> Seq.contains "http://targetedattacks.trendmicro.com/"
    |> should equal true

    http |> Seq.contains "http://babytree.com/" |> should equal true
    http |> Seq.contains "http://go.com/" |> should equal true

[<Test>]
let secondMiniCrawlerTest () =
    let answer = work "https://www.anekdot.ru/"
    answer |> Seq.isEmpty |> should equal true
