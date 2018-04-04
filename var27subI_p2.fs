(*
  read a,b  ( natural numbers)
  c <- 0
  d <- 0
  p <- 1
┌ while a+b+c>0 do
│    c <- a%10+b%10+c
│    d <- d+(c%10)*p
│    p <- p*10
│    a <- [a/10]
│    b <- [b/10]
│    c <- [c/10]
└■
  write d 
*)

open System
printf "a="
let a=int32(Console.ReadLine())
printf "b="
let b=int32(Console.ReadLine())
let rec whileLoop a b c d p=
    match a+b+c>0 with
    | false -> d
    | true -> let c=a%10+b%10+c
              let d=d+(c%10)*p
              whileLoop (a/10) (b/10) (c/10) d (p*10)

let res=whileLoop a b 0 0 1
printfn "%i" res