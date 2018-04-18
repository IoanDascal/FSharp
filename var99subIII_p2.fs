(*
    Implement in F# next C++ function:
 void S(int x)
 {
      cout<<'*';
      if (x>1) 
      {
          cout<<'*';
          S(x-1);
      }
 }
*)

let rec S x=
    printf "*"
    if x>1 then 
        printf "*"
        S (x-1)

let res =S 2