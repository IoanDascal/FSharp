(*
     Implement in f# next C++ function:
 int f(int n)
 { 
     if(n==0)
         return 0;
     else 
         return n%2+f(n/2);
 }
*)
let rec f n=
    match n with
    | 0 -> 0
    | _ -> n%2+f (n/2) 
let res= f 100
printfn "res=%i" res