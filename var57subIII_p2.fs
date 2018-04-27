(*
    Implement in F# next C++ function:
 void f(int x)
 {
     if(x) 
     {
         if(x%3==0)
         {
             cout<<3;
             f(x/3);
         }
         else
         {
             f(x/3);
             cout<<x%3;
         }
     }
 }
*)

let rec f x=
    match x with 
    | x when x=0 -> ()
    | _ -> match x%3 with
           | 0 -> printf "3"
                  f (x/3)
           | _ -> f (x/3)
                  printf "%i" (x%3)

let res=f 38
printfn ""
let res1=f 0
