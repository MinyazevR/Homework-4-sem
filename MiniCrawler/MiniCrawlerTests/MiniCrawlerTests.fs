module MiniCrawlerTests

open NUnit.Framework
open MiniCrawler
open FsUnit

[<Test>]
let firstMiniCrawlerTest () =
    let answer =
        work "https://github.com/MinyazevR/HTTP-List"
        |> Async.RunSynchronously
        |> Seq.choose id
        |> Seq.map (fun (html, url) -> html.Length, url)
    let expected = seq {(57641, "http://www.socialstudieshelp.com/")
                        (12283, "http://targetedattacks.trendmicro.com/")
                        (32, "http://streamhd4k.com/")
                        (1214, "http://salem.lib.virginia.edu")
                        (58188, "http://www.renewaloffaith.org")
                        (38727, "http://www.grose.us")
                        (143988, "http://www.southcn.com/")
                        (211508, "http://chinanetrank.com/")
                        (17398, "http://dedecms.com/")
                        (226, "http://www.faqs.org/faqs/")
                        (146, "http://www.gusuwang.com/")
                        (11321, "http://icio.us/")
                        (116142, "http://www.gunnalag.com/")
                        (5773, "http://soso.com/")
                        (156191, "http://www.rednet.cn/index.html")
                        (99291, "http://sneaindia.com/")
                        (52872, "http://www.piutetrailrvpark.com/")
                        (6199, "http://128.199.120.34/web/administrator/index.php")}
    answer |> should equal expected

[<Test>]
let secondMiniCrawlerTest () =
    let answer =
        work "https://www.anekdot.ru/"
        |> Async.RunSynchronously
        |> Seq.choose id
        |> Seq.map (fun (html, url) -> html.Length, url)

    answer |> Seq.isEmpty |> should equal true
