(*
     Implement in f# next C++ function:
 void f(char c)
 {
      if (c>’A’) 
          f(c-1);
      cout<<c;
      if (c>’A’) 
          f(c-1);
 } 
*)
let rec f c=
    if c>'A' then printf "-";f (char(int(c)-1))
    printf "%c" c
    if c>'A' then printf "=";f (char(int(c)-1))
let res=f 'C'
printfn ""