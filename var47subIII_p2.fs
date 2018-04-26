(*
    Implement in F# next C++ function:
 long f(int n)
 {
     if(n<0) 
         return 0;
     else 
         return f(n-2)+n;
 } 
*)

let rec f n=
    if n<0 then 0 else f (n-2)+n 

let res=f 5
printfn "%i" res
let res1=f 100
printfn "%i" res1