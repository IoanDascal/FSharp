(*
 read a,b   ( natural numbers, a ≤ b ) 
 k <- 0 
┌ for i <- a,b do
│   n <-i
│   c <-0 
│┌ while n>0 do
││┌ if n%2=1 then
│││  c <- c+1 
││└■
││  n <- [n/10] 
│└■
│┌ if c>0 then
││   k <- k+1 
│└■
└■
 write k 
*)
open System
printf " a="
let a=int(Console.ReadLine())
printf " b="
let b=int(Console.ReadLine())

let rec whileLoop n c=
    match n with
    | 0 -> c
    | _ -> match n%2 with 
           | 1 -> whileLoop (n/10) (c+1)
           | _ -> whileLoop (n/10) c
let rec forLoop a b k=
    match a=b+1 with
    | true -> k 
    | false -> let c= whileLoop a 0
               match c with
               | 0 -> forLoop (a+1) b k
               | _ -> forLoop (a+1) b (k+1)
    

let res=forLoop a b 0
printfn "%i" res
