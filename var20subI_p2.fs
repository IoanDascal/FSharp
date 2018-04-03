(*
 read n ( natural number)
 a <- n%10
 m <- a
┌ while n>9 do
│   n <- [n/10]
│   b <- n%10
│┌ if a>b then
││    m <- m*10+b
││    a <- b
│└■
└■
 write m
*)
open System
printf " n="
let n=int(Console.ReadLine())
let rec whileLoop a b m n=
    match n>0 with
    | false -> m 
    | true -> if a>b then
                  whileLoop b (n/10%10) (m*10+b) (n/10)
              else 
                  whileLoop a (n/10%10) m (n/10)

let res=whileLoop (n%10) (n/10%10) (n%10) n
printfn "%i" res
        