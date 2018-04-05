(*
  read n,k  ( natural numbers, k≤9)
  nr <- 0
  p <- 1
┌ while n≠ 0 do
│   c <- n%10
│   nr <- nr+c*p
│   p <- p*10
│ ┌ if c=k then
│ │    nr <- nr+c*p
│ │    p <- p*10
│ └■
│   n <- [n/10]
└■
  n <- nr
  write n 
*)

open System
printf "n="
let n=uint32(Console.ReadLine())
printf "k="
let k=uint32(Console.ReadLine())
let rec whileLoop n nr p=
    match n<>0u with
    | false -> nr
    | true -> let c=n%10u
              let nr,p=if c=k then (nr+c*p,p*10u) else (nr,p)
              whileLoop (n/10u) (nr+c*p) (p*10u)

let nr=whileLoop n 0u 1u
printfn "%u" nr