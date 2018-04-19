(*
    Implement in F# next C++ function:
 void f (int n, int x)
 {
      if(x>n)
      cout<<0; 
  else
      if(x%4<=1)
          f(n,x+1);
      else
      {
           f(n,x+3);
           cout<<1;
      }
 }
*)
let rec f n x=
    match x>n with
    | true -> printf "0"
    | false -> match x%4<=1 with
               | true -> f n (x+1)
               | false -> f n (x+3)
                          printf "1"

let res =f 15 2