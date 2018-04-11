(*
 read x,y   ( natural numbers >0)
┌ if x<y then
│    x↔y
└■
 n <- 0
┌ while x>=y do
│    x <- x-y
│    n <- n+1
└■
 write n, x 
*)

open System
printf "x="
let x=int32(Console.ReadLine())
printf "y="
let y=int32(Console.ReadLine())
let (x1,y1)=if x<y then y,x else x,y
let rec whileLoop x n=
    match x>=y1 with
    | false -> n,x
    | true -> whileLoop (x-y) (n+1)

let res=whileLoop x1 0
printfn "n=%i  x=%i" (fst res) (snd res)
