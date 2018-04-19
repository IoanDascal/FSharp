(*
    Implement in F# next C++ function:
 int f(int a, int b)
 {
     if (b<1) 
        return -1;
     else if (a%b==0)
        return 1+f(a/b,b);
     else
        return 0; }
*)
let rec f a b=
    match b<1 with
    | true -> -1
    | false -> match a%b with
               | 0 -> 1+ (f (a/b) b)
               | _ -> 0

let rez1=f 15 2
printfn "%i" rez1
let rez2=f 128 2
printfn "%i" rez2