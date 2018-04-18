(*
    Implement in F# next C++ function:
 int Min(int x)
 {
      int c;
      if (x==0) 
          return 9;
      else 
      {
          c=Min(x/10);
          if (c < x%10) 
              return c;
          else 
              return x%10;
      }
 } 
*)

let rec Min x=
    if x=0 then 9
    else let c=Min (x/10)
         if c<x%10 then c
         else x%10

let res =Min 547628
printfn "%i" res