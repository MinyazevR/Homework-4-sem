open System.Collections.Generic

type Computer =
    { id: int
      probabilityOfInfection: float }


type LocalNet(computers: Map<Computer, seq<Computer>>) =
    let computers = computers
    member this.Size = computers.Count
    member this.GetNeighbors computer = computers[computer]

type Virus(localNet: LocalNet, initiallyInfectedComputers: seq<Computer>) =
    let localNet = localNet
    //let initiallyInfectedComputers = initiallyInfectedComputers
    let mutable infectedComputers = HashSet(initiallyInfectedComputers)
    let mutable computersMayBeInfected = []

    let addComputersMayBeInfected () =
        let items =
            [ for x in infectedComputers do
                  for t in (localNet.GetNeighbors x) -> t ]
            |> List.distinct
            |> List.filter (fun x -> not (infectedComputers.Contains x))
            |> List.filter (fun x -> x.probabilityOfInfection > 0)

        computersMayBeInfected <- items

    member this.InfectTheComputers() =
        if localNet.Size = infectedComputers.Count then
            infectedComputers
        else
            addComputersMayBeInfected ()

            if computersMayBeInfected.IsEmpty then
                infectedComputers
            else
                infectedComputers.UnionWith(
                    List.filter
                        (fun x -> System.Random().NextDouble() < x.probabilityOfInfection)
                        computersMayBeInfected
                )

                infectedComputers
