(*
    Implement in F# next C++ function:
 int bac(int u, int x) 
 {
     if (u<x)
         return 0; 
     if (x==u)
         return 1; 
     if (u%x==0)
         return 0; 
     return 
         bac(u,x+1); 
 }
*)

let rec bac u x=
    match u<x with
    | true -> 0
    | false -> match x=u with
               | true -> 1
               | false -> match u%x=0 with
                          | true -> 0
                          | false -> bac u (x+1)

let res=bac 10 4
printfn "%i" res
let res1=bac 13 4
printfn "%i" res1