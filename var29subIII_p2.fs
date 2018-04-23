(*
    Implement in F# next C++ function:
 void p (int x)
 {
     cout<<x;
     if(x!=0)
     {
         p(x/10);
         cout<<x%10;
      }
 }
*)
let rec p x=
    printf "%i" x
    match x<>0 with
    | false -> ()
    | true -> p (x/10)
              printf "%i" (x%10)
let res=p 123
printfn ""