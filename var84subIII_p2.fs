(*
     Implement in F# next C++ function:
 int f(int x)
 {
      if(x==0)
          return 1;
      else
          return 1+f(x-1);
 }
*)

let rec f x=
    if x=0 then 1
        else 1+f (x-1) 

let res=f 1
printfn "%i" res
let res1=f 100
printfn "%i" res1