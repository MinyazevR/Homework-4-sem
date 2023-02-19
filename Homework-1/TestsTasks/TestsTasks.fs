module TestsTasks
open Homework_1.Factorial
open Homework_1.Fibonacci
open Homework_1.NumberSearch
open Homework_1.ReverseList
open Homework_1.SeriesOfDegree
open NUnit.Framework

let dataForFactorialFunction =
    [
    TestCaseData(factorial 0 , 1);
    TestCaseData(factorial 1, 1);
    TestCaseData(factorial 8, 40320);
    TestCaseData(2, 2);
    TestCaseData(factorial -1 , 0);
    TestCaseData(factorial -123, 0);
    TestCaseData(factorial -12, 0)
    ]
    
let dataForFibonacciFunction =
    [
    TestCaseData(fibonacci 0 , 0);
    TestCaseData(fibonacci 1, 1);
    TestCaseData(fibonacci 2, 1);
    TestCaseData(fibonacci 3, 2);
    TestCaseData(fibonacci 4 , 3);
    TestCaseData(fibonacci 5, 5);
    TestCaseData(fibonacci 6, 8);
    TestCaseData(fibonacci -1, -1);
    TestCaseData(fibonacci -2, -1);
    TestCaseData(fibonacci -100, -1);
    ]
    
let validDataForNumberSearchFunction =
    [
    TestCaseData(tryFindIndex [1; 2; 3;] 1, Some 0);
    TestCaseData(tryFindIndex [1; 1; 1;] 1, Some 0);
    TestCaseData(tryFindIndex [1; 2; 3; 4; 5; 3;] 3, Some 2);
    TestCaseData(tryFindIndex [1; 1; 3; 3; 4;] 4, Some 4);
    ]
        
let dataForReverseListFunction =
    [
    TestCaseData(rev [1; 2; 3; 4; 5; 6], [6; 5; 4; 3; 2; 1]);
    TestCaseData(rev [], []);
    TestCaseData(rev [1], [1]);
    TestCaseData(rev [1; 1], [1; 1]);
    TestCaseData(rev ["a"; "b"] , ["b"; "a"]);
    ]
    
let dataForSeriesOfDegreeFunction =
    [
    TestCaseData(seriesOfDegree 1 2, [2.0; 4.0; 8.0]);
    TestCaseData(seriesOfDegree 0 0, [1.0]);
    TestCaseData(seriesOfDegree 0 1, [1.0; 2.0]);
    TestCaseData(seriesOfDegree 0 5, [1.0; 2.0; 4.0; 8.0; 16.0; 32.0]);
    ]
    
[<TestCaseSource(nameof(dataForFactorialFunction));
  TestCaseSource(nameof(dataForFibonacciFunction));
  TestCaseSource(nameof(validDataForNumberSearchFunction));
  TestCaseSource(nameof(dataForSeriesOfDegreeFunction));
  TestCaseSource(nameof(dataForReverseListFunction))>]

let ShouldFunctionsReturnRightValue x y =
    Assert.AreEqual(x, y)