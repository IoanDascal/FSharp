(*
    Implement in F# next C++ function:
 int f(int x,int y)
 {
     if(x<=y) 
         return x-y;
     return f(y-x,x-1)+3;
 } 
*)

let rec f x y=
    if x<=y then x-y else f (y-x) (x-1)+3

let res=f 7 11
printfn "%i" res
let res1=f 11 7
printfn "%i" res1