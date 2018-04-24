(*
    Implement in F# next C++ function:
 int sc(long x)
 {
     if(x<10) 
         return x;
     return sc(x/10)+x%10;
 } 
*)

let rec sc x=
    match x<10 with
    | true -> x
    | false -> sc (x/10)+x%10

let res= sc 10
printfn "%i" res
let res1= sc 901234
printfn "%i" res1