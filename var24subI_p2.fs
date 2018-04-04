(*
  read a,b  ( natural numbers)
  p <- a
  q <- b
┌ if p=0 or q=0 then
│    p <- p*q
│    q <- p*q
└■
┌ while p≠q do
│ ┌ if p<q then
│ │    p <- p+a
│ │ else
│ │    q <- q+b
│ └■
└■
 write p 
*)

open System
printf "a="
let a= int32(Console.ReadLine())
printf "b="
let b= int32(Console.ReadLine())
let p=a
let q=b
let pq=if p=0 || q=0 then p*q,p*q else p,q  
let rec whileLoop p q=
    match p<>q with   
    | false -> p
    | true -> match p<q with
              | true -> whileLoop (p+a) q
              | false -> whileLoop p (q+b)

let res=whileLoop (fst pq) (snd pq)
printfn "%i" res