let rec f n=
    match n with
    | 0 | 1 -> 1
    | _ -> 2*(f (n-1))+2*(f (n-2))

let res=f 3
printfn "res=%i" res