(*
     Implement in F# next C++ function:
 void F(int x)
 {
      if(x)
      {
           F(x/2);
           cout << x%10;
      }
} 
*)

let rec F x=
    if x<>0 then 
        F (x/2)
        printf "%i" (x%10)

let res=F 56
printfn ""