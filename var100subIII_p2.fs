(*
    Implement in F# next C++ function:
 void F(int x) 
 {
     cout<<x;
     if(x>=3)
         F(x-2);
     cout<<x-1;
} 
*)

let rec F x=
    printf "%i" x
    if x>=3 then F (x-2)
    printf "%i" (x-1)

let res=F 5