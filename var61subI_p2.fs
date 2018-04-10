(*
  read a,b (natural numbers with equal number of digits )
  n <- 0
┌ while a≠b do
│    x <- a%10
│    y <- b%10
│┌ if x<y then
││    n <- n*10+x
││ else
││    n <- n*10+y
│└■
│  a <- [a/10]
│  b <- [b/10]
└■
  write n 
*)

open System
printf "a="
let a=int32(Console.ReadLine())
printf "b="
let b=int32(Console.ReadLine())
let rec whileLoop a b (n:int)=
    match a<>b with
    | false -> n
    | true -> let x=a%10
              let y=b%10
              let n=if x<y then (n*10+x) else (n*10+y)
              whileLoop (a/10) (b/10) n 

let n=whileLoop a b 0
printfn "%i" n