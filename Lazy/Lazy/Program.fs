module Lazy

open System
open System.Threading

type ILazy<'T> =
    abstract member Get: unit -> Option<'T>

type MultiThreadedLazy<'T>(supplier: unit -> Option<'T>) =
    let mutable isAlreadyCounted = false
    let mutable value: Option<'T> = None
    member private this.lockObject = Object()

    interface ILazy<'T> with
        member this.Get() =
            if not (Volatile.Read(ref isAlreadyCounted)) then
                lock this.lockObject (fun () ->
                    if not (Volatile.Read(ref isAlreadyCounted)) then
                        value <- supplier ()
                        Volatile.Write(ref isAlreadyCounted, true))

            value

type SingleThreadedLazy<'T>(supplier: unit -> Option<'T>) =
    let mutable isAlreadyCounted = false
    let mutable value: Option<'T> = None

    interface ILazy<'T> with
        member this.Get() =
            if not isAlreadyCounted then
                value <- supplier ()
                isAlreadyCounted <- true

            value

type LockFreeLazy<'T>(supplier: unit -> Option<'T>) =
    let mutable isAlreadyCounted = 0
    let mutable value: Option<'T> = None

    interface ILazy<'T> with
        member this.Get() =
            if Volatile.Read(ref isAlreadyCounted) = 0 then
                if Interlocked.CompareExchange(ref isAlreadyCounted, 1, 0) = 0 then
                    value <- supplier ()

            value
