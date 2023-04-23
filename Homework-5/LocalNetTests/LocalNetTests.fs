module LocalNetTests

open System.Collections.Generic
open NUnit.Framework
open FsUnit
open LocalNet

[<Test>]
let Test1 () =
    let firstComputer = { id = 1; probabilityOfInfection = 1.0 }
    let secondComputer = { id = 1; probabilityOfInfection = 1.0 }
    let thirdComputer = { id = 1; probabilityOfInfection = 1.0 }

    let adjacencyMap =
        Map
            [ (firstComputer,
               seq {
                   secondComputer
                   thirdComputer
               })
              (secondComputer, seq { firstComputer })
              (thirdComputer, seq { firstComputer }) ]

    let localNet = LocalNet(adjacencyMap)
    let virus = Virus(localNet, seq { firstComputer })
    let result = virus.InfectTheComputers()
    let hs = HashSet()
    hs.Add firstComputer |> ignore
    hs.Add secondComputer |> ignore
    hs.Add thirdComputer |> ignore
    result |> should equal hs

[<Test>]
let Test2 () =
    let firstComputer = { id = 1; probabilityOfInfection = 1.0 }
    let secondComputer = { id = 1; probabilityOfInfection = 0.0 }
    let thirdComputer = { id = 1; probabilityOfInfection = 0.0 }

    let adjacencyMap =
        Map
            [ (firstComputer,
               seq {
                   secondComputer
                   thirdComputer
               })
              (secondComputer, seq { firstComputer })
              (thirdComputer, seq { firstComputer }) ]

    let localNet = LocalNet(adjacencyMap)
    let virus = Virus(localNet, Seq.empty)
    let result = virus.InfectTheComputers()
    let hs = HashSet()
    result |> should equal hs
