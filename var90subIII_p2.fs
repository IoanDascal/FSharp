(*
    Implement in F# next C++ function:
 void f(char c) 
 {
     if (c != 'e')
     {
         f(c+1);
         cout<<c;
     }
 }
*)

let rec f c=
    match c<>'e' with
    | false -> ()
    | true -> f (char(int(c)+1))
              printfn "%c" c

let res=f 'a'
