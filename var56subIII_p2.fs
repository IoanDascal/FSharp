(*
    Implement in F# next C++ function:
 int f(int n,int c)
 {
     if(n==0)
         return 0;
     if(n%10==c)
         return n%100+f(n/10,c);
     return f(n/10,c);
 } 
*)

let rec f n c=
    match n with
    | 0 -> 0
    | _ -> match n%10=c with
           | true -> n%100 + f (n/10) c
           | false -> f (n/10) c

let res=f 12 3
printfn "%i" res
let res1=f 21114 1
printfn "%i" res1