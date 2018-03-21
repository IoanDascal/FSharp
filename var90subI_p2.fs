(*
 read a, b, k ( natural numbers)
 t <- a
 p <- 0
┌ while t≤b do
│┌ if k=t%10 then
││    write t
││    p <- 1
│└■
│ t <- t+1
└■
┌ if p=0 then
│    write -1
└■
*)

open System
printf "a="
let a=int32(Console.ReadLine())
printf "b="
let b=int32(Console.ReadLine())
printf "k="
let k=int32(Console.ReadLine())
let rec whileLoop t p=
    match t<=b with
    | false -> printfn ""
               p
    | true -> match k=t%10 with
              | false -> whileLoop (t+1) p   
              | true -> printf "%i " t
                        whileLoop (t+1) 1
let p=whileLoop a 0
if p=0 then
    printfn " -1"