module Homework_1.NumberSearch
open Microsoft.FSharp.Collections

/// <summary>
/// Function for finding the first occurrence of an element in the list
/// </summary>
/// <param name="ls">List</param>
/// <param name="item">IItem</param>
/// <returns>Returns the first element for which the given function returns True. Return None if no such element exists.</returns>
let tryFindIndex ls item =
   let rec findIndex ls item iter = 
      match ls with
      | head :: _ when head = item -> Some iter
      | _ :: tail -> findIndex tail item (iter + 1)
      | _ -> None
   findIndex ls item 0

// inputs |> List.tryFindIndex (fun elm -> elm = item)