(*
 read a,n  (natural numbers)
┌ for i=1,n do
│┌ if i%2=0 then
││    a <- a-i 
││ else
││    a <- a+i 
│└■
└■
 write a 
*)

open System
printf "a="
let a=uint32(Console.ReadLine())
printf "n="
let n=uint32(Console.ReadLine())
let rec forLoop a i=
    match i<=n with
    | false -> a
    | true -> match i%2u=0u with
              | true -> forLoop (a-i) (i+1u)
              | false -> forLoop (a+i) (i+1u)

let res=forLoop a 1u
printfn "%u" res
