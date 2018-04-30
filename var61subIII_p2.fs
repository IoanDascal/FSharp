(*
    Implement in F# next C++ function:
 int f(int x)
 {
     if(x>=1)
         return (a[x]+f(x-1))%10;
     else
         return 0;
 } 
*)

let a=[|0;12;35;2;8|]
let rec f x=
    if x>=1 then (a.[x]+f (x-1))%10 else 0

let res=f 1
printfn "%i" res
let res1=f 4
printfn "%i" res1
