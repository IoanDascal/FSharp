(*
    Implement in F# next C++ function:
 int f(int i)
 {
     if (i>12) 
         return 1;
     else 
         return 1+f(i+2);
 } 
*)

let rec f i=
    match i>12 with
    | true -> 1
    | false -> 1+f (i+2)

let res=f 7
printfn "%i" res
let res1=f 8
printfn "%i" res1