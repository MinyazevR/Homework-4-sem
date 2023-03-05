module Homework_2.PrimeGenerator

/// <summary>
/// Prime Number Generator
/// </summary>
let rec primeGenerator =
    let isPrime n =
        let rec check i =
            i > int (sqrt (float n)) || (n % i <> 0 && check (i + 1))

        check 2

    let rec answer n =
        seq {
            if isPrime n then
                yield n

            yield! answer (n + 1)
        }

    answer 2
