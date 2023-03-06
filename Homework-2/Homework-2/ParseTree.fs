module Homework_2.ParseTree

type Operations =
    | Addition
    | Subtraction
    | Division
    | Multiplication
    | Exponentiation

type ParseTree =
    | Tree of Operations * ParseTree * ParseTree
    | Tip of float

/// <summary>
/// Function for calculating the value of the parsing tree of an arithmetic expression
/// </summary>
/// <param name="tree">Parse Tree</param>
/// <returns>Value of arithmetic expression</returns>
let rec countExpression tree =
    match tree with
    | Tree(operation, l, r) ->
        match operation with
        | Addition -> countExpression l + countExpression r
        | Subtraction -> countExpression l - countExpression r
        | Division -> countExpression l / countExpression r
        | Multiplication -> countExpression l * countExpression r
        | Exponentiation -> countExpression l ** countExpression r
    | Tip a -> a
