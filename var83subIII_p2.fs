(*
    Implement in F# next C++ function:
 int f(int x)
 {
      if(x==0)
          return 0;
      else
          if(x%2==0)
              return 3+f(x/10);
          else 
              return 4+f(x/10);
 } 
*)

let rec f x=
    if x=0 then 0
        else match x%2 with
             | 0 -> 3+f (x/10)
             | _ -> 4+f (x/10)

let res= f 2
printfn "%i" res
let res1= f 123
printfn "%i" res1