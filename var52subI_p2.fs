(*
  read n  ( natural number, n>0) 
  d <- 0 
  c <- 0 
┌ for i <- 1,n do
│     read x  ( natural number, n>0)
│┌ while x%2=0 do
││       x <- [x/2]
││       d <- d+1 
│└■
│┌ while x%5=0 do
││       x <- [x/5]
││       c <- c+1 
│└■
└■
┌ if c<d then
│    write c    
│ else  
│    write d 
└■
*)

open System
printf "n="
let n =int32(Console.ReadLine())
let rec forLoop n i d c=
    match i<=n with
    | false -> (d,c)
    | true -> printf "x="
              let x =int32(Console.ReadLine())
              let rec whileLoop1 x d=
                  match x%2=0 with
                  | false -> x,d
                  | true -> whileLoop1 (x/2) (d+1)
              let x,d=whileLoop1 x d
              let rec whileLoop2 x c=
                  match x%5=0 with
                  | false -> c 
                  | true -> whileLoop2 (x/5) (c+1)
              let c=whileLoop2 x c 
              forLoop n (i+1) d c 
let d,c=forLoop n 1 0 0
if c<d then
    printfn "c=%i" c 
    else 
        printfn "d=%i" d