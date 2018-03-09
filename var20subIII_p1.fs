let rec f x=
    match x with
    | 0 -> 0
    |_ -> x+(f (x-1))

let res= f 5
printfn "%i" res