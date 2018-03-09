let rec f n y=
    match n with
    | 0 -> 0
    | _ -> y+1+f (n-1) (y+1)

let res=f 3 1
printfn "f=%i" res