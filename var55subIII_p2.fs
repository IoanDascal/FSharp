(*
    Implement in F# next C++ function:
 int f(int n)
 { 
     if (n>20) 
         return 0;
     else 
         return 5+f(n+5);
} 
*)

let rec f n=
    if n>20 then 0 else 5+f (n+5)

let res=f 25
printfn "%i " res
let res1=(f 1)+(f 5)+(f 15)
printfn "%i " res1
