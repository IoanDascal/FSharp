(*
 read n   ( natural number, n>0)
 read a   ( natural number) 
 k <- 0 
┌ for i <- 2,n do
│     read b  ( natural number)
│┌ if a%10=b%10 then
││    k <- k+1 
││ else
││    k <- k-1 
│└■
│  a <- b 
└■
  write k 
*)

open System
printf "n="
let n=int32(Console.ReadLine())
printf "a="
let a=int32(Console.ReadLine())
let rec forLoop n i a k=
    match i<=n with
    | false -> k
    | true -> printf "b="
              let b=int32(Console.ReadLine())
              let k=if a%10=b%10 then (k+1) else (k-1)
              forLoop n (i+1) b k

let k=forLoop n 2 a 0
printfn "k=%i" k