(*
 read n,k ( natural numbers)
 p <- 1
┌ while n>0 and k>0 do
│   c <- n%10
│ ┌ if c%2=1 then
│ │    p <- p*c
│ └■
│   n <- [n/10]
│   k <- k-1
└■
 write p 
*)

open System
printf "n="
let n=int32(Console.ReadLine())
printf "k="
let k=int32(Console.ReadLine())
let rec whileLoop n k p=
    match n>0 && k>0 with
    | false -> p
    | true -> match n%2=1 with
              | true -> whileLoop (n/10) (k-1) (p*(n%10))
              | false -> whileLoop (n/10) (k-1) p   

let p=whileLoop n k 1
printfn "%i" p