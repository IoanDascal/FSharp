(*
    Implement in F# next function:
         | 8,   if n=1
    f(n)=|
         | 2*f(n-1)-4,   if n>1
    where n is a natural number.
*)

let rec f n=
    match n=1 with
    | true -> 8
    | false -> 2*f (n-1)-4

let res=f 6
printfn "%i" res
let res1=f 9
printfn "%i" res1
let res2=f 10
printfn "%i" res2