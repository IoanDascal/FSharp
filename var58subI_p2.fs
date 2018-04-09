(*
 read n  ( natural number)
 q <- 1 
┌ while n>0 do
│┌ if n%5=0 then
││    q <- q*10 
││ else 
││    q <- q*10+1
│└■
│  n <- [n/5] 
└■
 write q 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop n q=
    match n>0 with
    | false -> q
    | true -> let q=if n%5=0 then (q*10) else (q*10+1)
              whileLoop (n/5) q

let q=whileLoop n 1
printfn "q=%i" q 