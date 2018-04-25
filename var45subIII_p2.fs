(*
    Implement in F# next C++ function:
 int f(int x)
 {
     if(x<1)
         return 1;
     else 
         return f(x-3)+1;
 } 
*)

let rec f x=
    if x<1 then 1 else f (x-3)+1

let res=f 4
printfn "%i" res

let res1=f 11
printfn "%i" res1