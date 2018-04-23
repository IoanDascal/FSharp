(*
    Implement in F# next C++ function:
 int f (int x,int y)
 {
     if(x<y)
         return 1+f(x+1,y);
     if(y<x)
         return 1+f(y+1,x);
     return 1;
 }
*)
let rec f x y=
    match x=y with
    | true -> 1
    | false -> match x<y with
               | true -> 1+(f (x+1) y)
               | false -> 1+(f (y+1) x)
let res=f 13 4
printfn "%i" res