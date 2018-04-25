(*
    Implement in F# next C++ function:
 int f(int n)
 {
     if(n<=0)
         return 0;
     else 
         return f(n-1)+2*n;
 } 
*)

let rec f n=
    if n<=0 then 0 else f (n-1)+2*n

let res=f 10100
printfn "%i" res