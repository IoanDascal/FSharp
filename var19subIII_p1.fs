(*
     Implement in f# next C++ function:
 int F(int x)
 {
     if (x<=1) 
         return x;
     else 
         return x+F(x-2);
 } 
*)
let rec F x=
    if x<=1 then x else x+F (x-2)
let res=F 18
printfn "%i" res