module LambdaInterpreter

type Term =
    | Variable of string
    | Application of Term * Term
    | Abstraction of string * Term

let rec isFree term variable =
    match term with
    | Variable x -> x = variable
    | Application(S, T) -> isFree S variable || isFree T variable
    | Abstraction(x, S) -> variable <> x && isFree S variable

let rec substitution term T variable =
    match term with
    | Variable x when x = variable -> T
    | Variable _ -> term
    | Application(S1, S2) -> Application(substitution S1 T variable, substitution S2 T variable)
    | Abstraction(x, _) when variable = x -> term
    | Abstraction(y, S) when (not (isFree S variable)) || (not (isFree T y)) ->
        Abstraction(y, substitution S T variable)
    | Abstraction(y, S) ->
        let app = Application(S, T)

        let freeVariables =
            [ 'a' .. 'z' ] |> List.filter (fun a -> not (isFree app (string a)))

        let getName =
            if not freeVariables.IsEmpty then
                string freeVariables.Head
            else
                let rec lengthenName newVariable =
                    if not (isFree app newVariable) then
                        newVariable
                    else
                        lengthenName newVariable + newVariable

                lengthenName "z"

        Abstraction(getName, substitution (substitution S (Variable getName) y) T variable)

let rec beta_reduce term =
    match term with
    | Variable _ -> term
    | Abstraction(x, S) -> Abstraction(x, beta_reduce S)
    | Application(S, T) ->
        match beta_reduce S with
        | Abstraction(x, e) -> beta_reduce (substitution e T x)
        | x -> Application(beta_reduce x, beta_reduce T)
