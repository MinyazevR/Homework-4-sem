module ParenthesisTests

open NUnit.Framework
open FsUnit
open Homework_4.Parenthesis

let testCaseData =
    [
        checkCorrectOrderBrackets "", Success;
        checkCorrectOrderBrackets "()", Success;
        checkCorrectOrderBrackets "{}", Success;
        checkCorrectOrderBrackets "[]", Success;
        checkCorrectOrderBrackets "[({})]", Success;
        checkCorrectOrderBrackets "([()])", Success;
        checkCorrectOrderBrackets "({}[]([]))", Success;
        checkCorrectOrderBrackets "([](){[]})", Success;
        checkCorrectOrderBrackets "[", Error "incorrect number of parenthesis";
        checkCorrectOrderBrackets "{", Error "incorrect number of parenthesis";
        checkCorrectOrderBrackets "(", Error "incorrect number of parenthesis";
        checkCorrectOrderBrackets ")", Error "incorrect number of parenthesis";
        checkCorrectOrderBrackets "}", Error "incorrect number of parenthesis";
        checkCorrectOrderBrackets "]", Error "incorrect number of parenthesis";
        checkCorrectOrderBrackets "((())}", Error "incorrect bracket";
        checkCorrectOrderBrackets "(}", Error "incorrect bracket";
        checkCorrectOrderBrackets "(})", Error "incorrect bracket";
    ] |> List.map (fun (x, y) -> TestCaseData(x, y))
        

[<TestCaseSource("testCaseData")>]
let Test (expected: Result, actual: Result) =
     actual |> should equal expected
