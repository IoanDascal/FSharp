(*
    Implement in F# next C++ function:
 int f(int x)
 {
     if (x<=99)
         return x%10 + x/10;
     else
         return f(x/10);
 }
*)

let rec f x=
    if x<=99 then 
        x%10+x/10 
    else 
        f (x/10)

let res=f 2318
printfn "%i" res  
