(*
    Implement in F# next C++ function:
 int f(int a,int b)
 {
     if(2*a>=b)
         return 0;
     if(b%a==0)
         return b-a;
     return f(a+1,b-1);
 } 
*)

let rec f a b=
    if 2*a>=b then 0 else if b%a=0 then (b-a) else f (a+1) (b-1)

let res=f 3 13
printfn "%i" res
let res1=f 1000 2009
printfn "%i" res1