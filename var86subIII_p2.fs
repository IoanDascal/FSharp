(*
     Implement in F# next C++ function:
 void f(int n)
 {
     cout<<"*";
     if(n>2)
     {
         f(n-1);
         cout<<"#"; 
     }
 }
*)

let rec f n=
    printf "*"
    if n>2 then f(n-1) else printf "#"

let res=f 4
printfn ""