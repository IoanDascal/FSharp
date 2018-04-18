(*
    Implement in F# next C++ function:
 void f(int x)
 {
     if (x<=10)
         cout<<0<<” ”;
     else
     {
         f(x-2);
         cout<<x<<” ”;
     }
 } 
*)

let rec f x=
    match x<=10 with
    | true -> printf "0 "
    | false -> f (x-2)
               printf "%i " x

let res=f 19