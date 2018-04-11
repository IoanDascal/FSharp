(*
 read x ( natural number, x >0)
 nr <- 0
┌ for i <- 1,x do
│    read n ( integer)
│┌ if n%x=0 then
││    nr <- nr+1
│└■
└■
 write nr
*)

open System
printf "x="
let x= int32(Console.ReadLine())
let rec forLoop i nr=
    match i<=x with
    | false -> nr
    | true -> printf "n="
              let n= int32(Console.ReadLine())
              let nr=if n%x=0 then (nr+1) else nr
              forLoop (i+1) nr

let nr=forLoop 1 0
printfn "nr=%i"  nr