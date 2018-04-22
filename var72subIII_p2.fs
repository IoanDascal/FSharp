(*
    Implement in F# next C++ function:
 void F(int x) 
 {
    if(x != 0) 
    { 
        F(x/2); 
        cout << x%2;
    } 
 } 
*)

let rec F x=
    match x with
    | 0 -> ()
    | _ -> F (x/2)
           printf "%i" (x%2)

let res=F 57
