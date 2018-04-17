(*
     Implement in F# next C++ function:
 void f(int n)
 {
      if(n>0)
      {
          cout<<n; 
          f(n-1);
          cout<<n;
      }
 }     
*)

let rec f n=
    match n>0 with
    | false -> ()
    | true -> printfn "%i" n
              f (n-1)
              printfn "%i" n

let res=f 4
printfn ""