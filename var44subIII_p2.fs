(*
    Implement in F# next C++ function:
 int f(int x,int y)
 {
     if(x==y)
         return x;
     else if(x<y)
         return f(x+1,y-1);
     else 
         return f(x-1,y);
 }
*)

let rec f x y=
    match x=y with
    | true -> x
    | false -> match x<y with
               | true -> f (x+1) (y-1)
               | false -> f (x-1) y

let res=f 6 5
printfn "%i" res

let res1=f 5 10
printfn "%i" res1