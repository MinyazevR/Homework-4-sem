module Homework_6.Workflow

/// <summary>
/// Workflow for string computation
/// </summary>
type Builder() =
    member this.Bind(x: string, f) =
        try
            let t = x |> int
            f t
        with :? System.FormatException ->
            None

    member this.Return(x) = Some x
