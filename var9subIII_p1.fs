let rec f n k=
    match n with
    | 0 -> 0
    | _ -> match n%10=k with
           | true -> 1+f (n/10) k 
           | false -> 0
let res=f 1213111 1
printfn "%i" res