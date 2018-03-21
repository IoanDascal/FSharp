(*
    Implement in F# next C++ snipet:
 int F(int n)
 {
     if(n==0 || n==1) return 1;
        else
            return 2*F(n-1)+2*F(n-2);}
*)
let rec f n=
    match n with
    | 0 | 1 -> 1
    | _ -> 2*(f (n-1))+2*(f (n-2))

let res=f 3
printfn "res=%i" res