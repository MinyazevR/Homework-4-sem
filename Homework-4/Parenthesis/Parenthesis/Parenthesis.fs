module Parenthesis

type Result =
    |Error of string
    |Success
    
/// <summary>
/// Is the character an opening parenthesis
/// </summary>
/// <param name="x">character</param>
let IsOpenParenthesis x = ['('; '{'; '['] |> List.contains x

/// <summary>
/// Is the character an closing parenthesis
/// </summary>
/// <param name="x">character</param>
let IsCloseParenthesis x = [')'; '}'; ']'] |> List.contains x

/// <summary>
/// Checking for the same type of closing and opening parenthesis
/// </summary>
let openingAndClosingOfTheSameType =
    function
    |'(', ')'
    |'{', '}'
    |'[', ']' -> true
    |_ -> false
        
/// <summary>
/// Checking the correctness of the parenthesis expression
/// </summary>
/// <param name="expressionFromParenthesis">Expression from parentheses</param>
let checkCorrectOrderBrackets expressionFromParenthesis =
    let rec helper lst openingParenthesis =
        match lst, openingParenthesis with
        |lstHead :: lstTail, openingBrackets when IsOpenParenthesis lstHead ->
            helper lstTail (lstHead :: openingBrackets)
        |lstHead :: lstTail, openingParenthesisHead :: openingParenthesisTail when IsCloseParenthesis lstHead ->
            if openingAndClosingOfTheSameType (openingParenthesisHead, lstHead) then helper lstTail openingParenthesisTail
            else Error "incorrect bracket"
        |[], [] -> Success
        |_, _ -> Error "incorrect number of parenthesis"
        
    helper (Seq.toList expressionFromParenthesis) []