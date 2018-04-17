(*
     Implement in F# next C++ function:
 void f(int n)
 {
     if (n==0) 
         return 1;
     else if (n==1) 
         return 2;
     else 
         return f(n-1)-f(n-2);
} 
*)

let rec f n=
    match n with
    | 0 -> 1
    | 1 -> 2
    | _ -> f (n-1)- f (n-2)

let res=f 1
printfn "%i" res
let res1=f 4
printfn "%i" res1