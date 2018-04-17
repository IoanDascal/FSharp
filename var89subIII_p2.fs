(*
    Implement in F# next C++ function:
 long f(int n)
 {
     if (n==0) 
         return 0;
     else  
         return n*n+f(n-1);
 } 
*)

let rec f n=
    match n with
    | 0 -> 0
    | _ -> n*n+f (n-1)

let res=f 0
printfn "%i" res
let res1=f 4
printfn "%i" res1