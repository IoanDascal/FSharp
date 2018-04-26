(*
    Implement in F# next C++ function:
 int f(int n)
 {
     if (n==0) 
         return 0;
     if(n%2==1)
         return n-f(n-1);
     return f(n-1)-n
 }
*)

let rec f n=
    match n with
    | 0 -> 0
    | _ -> match n%2=1 with
           | true -> n-f (n-1)
           | false -> f (n-1)-n

let res=f 4
printfn "%i" res
let res1=f 9
printfn "%i" res1