(*
    Implement in F# next C++ function:
 int f(int x)
 {
      if(x==50)
          return 1;
      else
          return 2+f(x-1);
 } 
*)

let rec f x=
    if x=50 then 1
        else
            2+f (x-1)

let res=f 51
printfn "%i" res
let res1=f 100
printfn "%i" res1