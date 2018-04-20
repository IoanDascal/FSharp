(*
     Implement in f# next C++ function:
 int f(int n)
 {
     if (n<=9) 
         return 0;
     if (n%4==0) 
         return 0;
     return 1+f(n-3);
 }
*)

let rec f n=
    match n<=9 with
    | true -> 0
    | false -> match n%4=0 with
               | true -> 0
               | false -> 1+f (n-3)

let res=f 17
printfn "%i" res
let res1=f 22
printfn "%i" res1