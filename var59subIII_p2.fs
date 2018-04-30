(*
    Implement in F# next C++ function:
 int f(int a,int b)
 {
     if(a<10)
         return b;
     return f(a/10,b)*10+b+1;
 } 
*)

let rec f a b=
    if a<10 then b else (f (a/10) b)*10+b+1

let res=f 12 5
printfn "%i" res
let res1=f 261 31
printfn "%i" res1