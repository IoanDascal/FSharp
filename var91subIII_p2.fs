(*
    Implement in F# next C++ function:
 void f(int i)
 {
      if (i>0)
      {
          cout<<i<<’ ’;
          f(i/2);
          cout<<i<<’ ’;
      }
 } 
*)

let rec f i=
    match i>0 with
    | true -> printf "%i " i
              f (i/2)
              printf "%i " i
    | false -> ()

let res=f 12
