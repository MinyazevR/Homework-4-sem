module PointFree

let first_step x l = List.map (fun y -> x * y) l
let second_step x = List.map (fun y -> (*) x y)
let third_step x = List.map ((*) x)
let fourth_step = List.map << (*)
