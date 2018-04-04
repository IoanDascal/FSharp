(*
  read n,m  ( natural numbers)
┌ while n≤m do
│     n <- n+1
│     m <- m-1
└■
┌ while m<n do
│     m <- m+1
│     n <- n-1
└■
  write n 
*)
printf " n="
let n=int(System.Console.ReadLine())
printf " m="
let m=System.Console.ReadLine() |> int
let rec whileLoop (n,m)=
    match n<=m with
    | false -> (n,m)
    | true -> whileLoop (n+1,m-1)
let rec whileLoop1 (n,m)=
    match m<n with
    | false -> (n,m)
    | true -> whileLoop1 (n-1,m+1)

let res=whileLoop1 (whileLoop (n,m))
printfn "%i" (fst res)