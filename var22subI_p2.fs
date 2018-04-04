(*
 read n ( înteger number )
┌ if n < 0 then
│    n <- -n
└■
 d <- 1
┌ for i <- 2,[n/2] do
│┌ if i|n then
││    d <- i
│└■
└■
 write d 
*)
open System
printf " n="
let n=int32(Console.ReadLine())
let m=if n<0 then -n else n
let rec forLoop i d m=
    match i<=m/2 with
    | false -> d
    | true -> match m%i with 
              | 0 -> forLoop (i+1) i m
              | _ -> forLoop (i+1) d m 
let d=forLoop 2 1 m
printfn "%i" d 