module Tests

open FsCheck
open FsUnit
open Homework_2
open Homework_2.NumberOfEvenNumbers
open Homework_2.PrimeGenerator
open Homework_2.TreeMap
open Homework_2.ParseTree
open NUnit.Framework

let firstCheck lst =
    numberOfEvenNumbersWithFilter lst = numberOfEvenNumbersWithMap lst

let secondCheck lst =
    numberOfEvenNumbersWithMap lst = numberOfEvenNumbersWithFold lst

Check.QuickThrowOnFailure firstCheck
Check.QuickThrowOnFailure secondCheck

let numberOfEvenNumbersCaseData =
    [ TestCaseData(numberOfEvenNumbersWithFilter [ 1; 2; 3 ], 1)
      TestCaseData(numberOfEvenNumbersWithFilter [], 0)
      TestCaseData(numberOfEvenNumbersWithFilter [ 1; 1; 1 ], 0)
      TestCaseData(numberOfEvenNumbersWithFilter [ 1; 2; 3; 4; 5; 2 ], 3)
      TestCaseData(numberOfEvenNumbersWithFilter [ 1; 1; 2; 3; 3; 4 ], 2) ]

let firstTree = TreeMap.Tree(30.0, TreeMap.Tip 10.0, TreeMap.Tip 20.0)
let secondTree = TreeMap.Tree(25.0, TreeMap.Tip 5.0, TreeMap.Tip 10.0)
let resultTree = TreeMap.Tree(20.0, firstTree, secondTree)
let firstExpectedTree = TreeMap.Tree(900.0, TreeMap.Tip 100.0, TreeMap.Tip 400.0)
let secondExpectedTree = TreeMap.Tree(625.0, TreeMap.Tip 25.0, TreeMap.Tip 100.0)
let expectedTree = TreeMap.Tree(400.0, firstExpectedTree, secondExpectedTree)

let treeMapCaseData =
    [ TestCaseData(map (fun x -> x * 2) (TreeMap.Tip 10), TreeMap.Tip 20)
      TestCaseData(map (fun x -> x ** 2.0) firstTree, firstExpectedTree)
      TestCaseData(map (fun x -> x ** 2.0) secondTree, secondExpectedTree)
      TestCaseData(map (fun x -> x ** 2.0) resultTree, expectedTree)
      TestCaseData(map (fun x -> x + x) (TreeMap.Tip "a"), TreeMap.Tip "aa") ]

let primeGeneratorCaseData =
    [ TestCaseData(primeGenerator |> Seq.item 0, 2)
      TestCaseData(primeGenerator |> Seq.item 1, 3)
      TestCaseData(primeGenerator |> Seq.item 19, 71)
      TestCaseData(primeGenerator |> Seq.item 39, 173)
      TestCaseData(primeGenerator |> Seq.item 59, 281)
      TestCaseData(primeGenerator |> Seq.item 79, 409)
      TestCaseData(primeGenerator |> Seq.item 99, 541)
      TestCaseData(primeGenerator |> Seq.item 119, 659)
      TestCaseData(primeGenerator |> Seq.item 139, 809)
      TestCaseData(primeGenerator |> Seq.item 159, 941)
      TestCaseData(primeGenerator |> Seq.item 179, 1069)
      TestCaseData(primeGenerator |> Seq.item 199, 1223)
      TestCaseData(primeGenerator |> Seq.item 219, 1373)
      TestCaseData(primeGenerator |> Seq.item 239, 1511)
      TestCaseData(primeGenerator |> Seq.item 259, 1657)
      TestCaseData(primeGenerator |> Seq.item 279, 1811)
      TestCaseData(primeGenerator |> Seq.item 299, 1987)
      TestCaseData(primeGenerator |> Seq.item 319, 2129)
      TestCaseData(primeGenerator |> Seq.item 339, 2287)
      TestCaseData(primeGenerator |> Seq.item 359, 2423)
      TestCaseData(primeGenerator |> Seq.item 379, 2617)
      TestCaseData(primeGenerator |> Seq.item 399, 2741)
      TestCaseData(primeGenerator |> Seq.item 419, 2903)
      TestCaseData(primeGenerator |> Seq.item 439, 3079)
      TestCaseData(primeGenerator |> Seq.item 459, 3257)
      TestCaseData(primeGenerator |> Seq.item 479, 3413)
      TestCaseData(primeGenerator |> Seq.item 499, 3571) ]

let additionTree = Tree(Operations.Addition, Tip 10.0, Tip 20.0)
let subtractionTree = Tree(Operations.Subtraction, Tip 10.0, Tip 20.0)
let divisionTree = Tree(Operations.Division, Tip 10.0, Tip 20.0)
let multiplicationTree = Tree(Operations.Multiplication, Tip 10.0, Tip 8.0)
let exponentiationTree = Tree(Operations.Exponentiation, Tip 2, Tip 3)
let firstParseTree = Tree(Operations.Addition, additionTree, divisionTree)

let secondParseTree =
    Tree(Operations.Division, multiplicationTree, exponentiationTree)

let parseTree = Tree(Operations.Multiplication, firstParseTree, secondParseTree)

let parseTreeCaseData =
    [ TestCaseData(countExpression additionTree, 30.0)
      TestCaseData(countExpression subtractionTree, -10.0)
      TestCaseData(countExpression divisionTree, 0.5)
      TestCaseData(countExpression multiplicationTree, 80.0)
      TestCaseData(countExpression exponentiationTree, 8)
      TestCaseData(countExpression parseTree, 200.0) ]

[<TestCaseSource(nameof numberOfEvenNumbersCaseData);
  TestCaseSource(nameof treeMapCaseData);
  TestCaseSource(nameof primeGeneratorCaseData)>]
let functionShouldReturnRightValue x y = x |> should equal y
