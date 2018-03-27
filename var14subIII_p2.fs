(*
    Implement in F# next C++ function:
 long f1(int c)
 {
      if (c%2==1) return 1;
      else return 2;
 }
 long f2(long n)
 {
      if (n==0) return 0;
      else return f1(n%10)+f2(n/10);
 }
*)
let f1 c=
    match c%2 with
    | 0 -> 2
    | _ -> 1
let rec f2 n=
    match n with
    | 0 -> 0
    | _ -> f1 (n%10) + f2 (n/10)

let res=f1 3
printfn "%i" res
let res1=f2 41382
printfn "%i" res1