(*
 read n, d   ( natural numbers >0)
 b <- 0
 v <- 0
┌ for i <- 1,n do
│    read x ( natural number >0)
│    a <- 0
│    aux <- x
│┌ while x % d = 0 do
││    a <- a+1
││    x <- [x/d]
│└■
│┌ if a>b then
││    b <- a
││    v <- aux
│└■
└■
  write v,’ ’,b
*)
 
open System
printf "n="
let n= int32(Console.ReadLine())
printf "d="
let d= int32(Console.ReadLine())
let rec forLoop i b v=
    match i<=n with
    | false -> v,b
    | true -> printf "x="
              let x= int32(Console.ReadLine())
              let aux=x
              let rec whileLoop x a=
                  match x%d=0 with
                  | false -> a
                  | true -> whileLoop (x/d) (a+1)
              let a=whileLoop x 0
              let v,b=if a>b then aux,a else v,b
              forLoop (i+1) b v
let v,b=forLoop 1 0 0
printfn "v=%i  b=%i" v b