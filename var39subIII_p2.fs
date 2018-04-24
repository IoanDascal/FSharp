(*
    Implement in F# next C++ function:
 int f(int x)
 {
     if(x<=4) 
         return x*x-3;
     return f(x-3)+4;
 }
*)

let rec f x=
    match x<=4 with
    | true -> x*x-3
    | false -> f (x-3)+4

let res=f 3
printfn "%i" res
let res1=f 8
printfn "%i" res1