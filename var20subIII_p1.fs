(*
     Implement in f# next C++ function:
 int F(int x)
 {
     if(x!=0) 
         return x+F(x-1);
     else
         return x;
 } 
*)
let rec f x=
    match x with
    | 0 -> 0
    |_ -> x+(f (x-1))

let res= f 5
printfn "%i" res