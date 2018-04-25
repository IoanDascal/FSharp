(*
    Implement in F# next C++ function:
 int f(int x)
 {
     if(x==0)
         return 0;
     else 
         return f(x-1)+2;
 } 
*)

let rec f x=
    if x=0 then x else f (x-1)+2

let res=f 3
printfn "%i" res

let res1=f 10
printfn "%i" res1