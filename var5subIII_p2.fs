(*
    Implement in F# next C++ function:
 void f ( int a, int b)
 {
      if(a<=b)
      { 
          f(a+1,b-2); 
          cout<<’*’;
      }
      else
          cout<<b;
 } 
*)
let rec f a b=
    match a<=b with
    | true -> f (a+1) (b-2)
              printf "%c" '*'
    | false -> printf "%i" b

let rez=f 3 17