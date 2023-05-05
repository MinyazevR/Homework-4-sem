module LazyTests

open System.Threading
open NUnit.Framework
open FsUnit
open Lazy

let firstTestCase =
    let values = [ 0; -1; 1 ]
    let mutable number = 0

    let t =
        seq {
            for value in values do
                yield TestCaseData(SingleThreadedLazy<int>(fun () -> Some value), Some value)
                yield TestCaseData(MultiThreadedLazy<int>(fun () -> Some value), Some value)
                yield TestCaseData(LockFreeLazy<int>(fun () -> Some value), Some value)
        }

    Seq.append
        t
        [ TestCaseData(
              SingleThreadedLazy<int>(fun () ->
                  number <- number + 1
                  Some number),
              Some 1
          ) ]


[<TestCaseSource(nameof firstTestCase)>]
let firstTest (lzy: ILazy<int>, expectedValue) =
    for _ in [ 1..10 ] do
        lzy.Get() |> should equal expectedValue

let secondTestCase =
    let mutable number = 0

    [ TestCaseData(MultiThreadedLazy<int>(fun () -> Some(Interlocked.Increment(ref number))), Some 1)
      TestCaseData(LockFreeLazy<int>(fun () -> Some(Interlocked.Increment(ref number))), Some 1) ]

[<TestCaseSource(nameof secondTestCase)>]
let secondTest (lzy: ILazy<int>, expectedValue) =
    let threads =
        [ for _ in [ 1..8 ] -> Thread(fun () -> (lzy.Get() |> should equal expectedValue)) ]

    for thread in threads do
        thread.Start()

    for thread in threads do
        thread.Join()