(*
 read a, b, p  ( natural numbers a,b,p>0 and a < b)
 nr <- 0
┌ for i <- a,b do
│     x <- i
│┌ while x≠0 and x%p≠0 do
││     x <- [x/10]
│└■
│┌ if x ≠ 0 then
││    nr <- nr+1
│└■
└■
 write nr
*)

open System
printf "a="
let a=int32(Console.ReadLine())
printf "b="
let b=int32(Console.ReadLine())
printf "p="
let p=int32(Console.ReadLine())
let rec forLoop i nr=
    match i<=b with
    | false -> nr 
    | true -> let rec whileLoop x=
                  match x<>0 && x%p<>0 with
                  | false -> x
                  | true -> whileLoop (x/10)
              let x=whileLoop i
              let nr=if x<>0 then nr+1 else nr
              forLoop (i+1) nr

let nr=forLoop a 0
printfn "nr=%i" nr