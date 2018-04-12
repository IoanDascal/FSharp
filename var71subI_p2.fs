(*
 s <- 0
 read n ( natural number, n<10)
┌ for i <- 1,n do
│    read x ( natural number)
│ ┌ while x>9 do
│ │    x <- [x/10]
│ └■
│ ┌ for j <- 1,i-1 do
│ │    x <- x*10
│ └■
│   s <- s + x
└■
 write s
*)

open System
printf "n="
let n=int32(Console.ReadLine())
let rec forLoop i s=
    match i<=n with
    | false -> s
    | true -> printf "x="
              let x=int32(Console.ReadLine())
              let rec whileLoop x=
                  match x>9 with
                  | false -> x
                  | true -> whileLoop (x/10)
              let x1=whileLoop x
              let rec innerForLoop j x=
                  match j<i with
                  | false -> x
                  | true -> innerForLoop (j+1) (x*10)
              let x2=innerForLoop 1 x1
              forLoop (i+1) (s+x2)

let s=forLoop 1 0
printfn "s=%i" s