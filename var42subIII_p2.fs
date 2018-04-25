(*
    Implement in F# next C++ function:
 int f(int x)
 {
     if(x%6==0)
         return x;
     else 
         return f(x-1);
 } 
*)

let rec f x=
    if x%6=0 then x else f (x-1)

let res=f 7
printfn "%i" res

let res1=f 100
printfn "%i" res1