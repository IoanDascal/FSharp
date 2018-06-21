(*
    Definition of Lucas numbers using pattern matching.
This is a tail recursive function.
*)
let rec Lucas x=
    match x with
    | x when x<=0 -> failwith "value must be greather than 0"
    | 1 -> 1
    | 2 -> 3
    | x -> Lucas (x-1) + Lucas (x-2)

printfn "Lucas 6=%i" (Lucas 6)