(*
     Implement in F# next C++ function:
 int F(int x) 
 {
     if(x == 0) return 0;
     if(x%10%2 == 0) return 2 + F(x/10);
     return 10 – F(x/10);
 } 
*)

let rec F x=
    match x=0 with
    | true -> 0
    | false -> match x%10%2=0 with
               | true -> 2+F (x/10)
               | false -> 10-F (x/10)

let res=F 2648
printfn "res=%i" res
let res1=F 2758
printfn "res=%i" res1
let res2=F 3759
printfn "res=%i" res2
let res3=F 37591
printfn "res=%i" res3