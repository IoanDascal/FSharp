let f1 c=
    match c%2 with
    | 0 -> 2
    | _ -> 1
let rec f2 n=
    match n with
    | 0 -> 0
    | _ -> f1 (n%10) + f2 (n/10)

let res=f2 41382
printfn "%i" res