(*
    Implement in F# next C++ function:
 int f (long n, int k)
 {
     if (n!=0)
         if(n%10==k)
             return 1+f(n/10,k);
         else
             return 0;
     else 
         return 0;}
*)
let rec f n k=
    match n with
    | 0 -> 0
    | _ -> match n%10=k with
           | true -> 1+f (n/10) k 
           | false -> 0
let res=f 1213111 1
printfn "%i" res