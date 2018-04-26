(*
    Implement in F# next C++ function:
 int f(int x)
 {
     if(x%3==0) 
         return 0;
     else 
         return 1+f(x/3);
 }
*)

let rec f x=
    if x%3=0 then 0 else 1+f (x/3)

let res=f 250
printfn "%i" res