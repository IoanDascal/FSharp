(*
 read n  ( natural number, n>0)
 k <- 9 
┌ for i <- 1,n do
│     read x   (natural number)
│     c <- [x/10]%10 
│┌ if c<k then
││    k <- c 
│└■
└■
 write k 
*)

open System
printf "n="
let n=int32(Console.ReadLine())
let rec forLoop i n k=
    match i<=n with
    | false -> k
    | true -> printf "x="
              let x=int32(Console.ReadLine())
              let c=x/10%10
              let k=if c<k then c else k
              forLoop (i+1) n k

let k=forLoop 1 n 9
printfn "k=%i" k

