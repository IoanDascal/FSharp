(*
    Implement in F# next C++ function:
 void f(int i)
 {
     if(i<=5)
     {
         cout<<i<<” ” ;
         f(i+1);
         cout<<i/2<<” ”;
     } 
 }
*)

let rec f i=
    match i<=5 with
    | false -> ()
    | true -> printf "%i " i
              f (i+1)
              printf "%i " (i/2)

let res =f 1