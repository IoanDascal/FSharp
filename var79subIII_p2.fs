(*
    Implement in F# next C++ function:
 int f(long x)
 {
      int y,z;
      if (x==0) 
          return x;
      else
      {
          y=x%10;
          z=f(x/10);
          if(y>z) 
              return y;
          else 
              return z;
      }
 } 
*)

let rec f x=
    match x=0 with
    | true -> x
    | false -> let y=x%10
               let z=f (x/10)
               if y>z then y else z

let res=f 8
printfn "res=%i" res
let res1=f 1209986
printfn "res1=%i" res1