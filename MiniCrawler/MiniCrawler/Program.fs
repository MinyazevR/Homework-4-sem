module MiniCrawler

open System.Text.RegularExpressions

let fetchAsync (url: string) =
    async {
        try
            let httpClient = new System.Net.Http.HttpClient()
            let! response = httpClient.GetAsync(url) |> Async.AwaitTask
            let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            return Some(content, url)
        with _ ->
            return None
    }

let work url =
    let x = Regex(@"a href=""http:(\S*)")
    let html: (string * string) option = url |> fetchAsync |> Async.RunSynchronously
    let matches = x.Matches(fst html.Value)

    let a =
        [ for x in matches -> x.Value[8 .. x.Value.Length - 2] |> fetchAsync ]
        |> Async.Parallel
        |> Async.RunSynchronously

    Seq.map (fun (t: string * string) -> t |> fst |> String.length, t |> snd) (Seq.choose id a)

let print answer =
    for i, j in answer do
        printfn $"{i} --- {j}"
