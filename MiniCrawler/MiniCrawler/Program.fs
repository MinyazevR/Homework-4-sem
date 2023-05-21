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

    [ for x in matches -> x.Value[8 .. x.Value.Length - 2] |> fetchAsync ]
    |> Async.Parallel

let print answer =
    for i, j in answer do
        printfn $"{i} --- {j}"
