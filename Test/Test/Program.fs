module Program

let supermap f lst = lst |> List. map f |> List.concat
        
let rhomb n =
    let rec space p x =
        if p = x then ""
        else " " + space p (x + 1)
    let rec stars p x =
        if p = x then "*"
        else "*" + stars p (x + 1)
    let rec solve half row =
        if row = half + 1 then ""
        else
            (space half row) + (stars (row * 2 - 1) 1) + "\n" + (solve half (row + 1))
    let rec second_solve half row =
        if row = 0 then ""
        else
            (space half row) + (stars (row * 2 - 1) 1) + "\n" + (second_solve half (row - 1))
    solve n 1 + second_solve n (n - 1)
    
type ConcurrentStack<'T>() =
    let mutable stack: List<'T> = []

    member this.Push value =
        lock stack (fun () -> stack <- value :: stack)

    member this.TryPop() =
        lock stack (fun () ->
            match stack with
            | head :: tail ->
                stack <- tail
                Some head
            | [] -> None)