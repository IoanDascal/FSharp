let rec f n=
    match n with
    | 0 -> 0
    | _ -> n%2+f (n/2) 
let res= f 100
printfn "res=%i" res