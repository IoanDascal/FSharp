(*
 read a,n  ( natural numbers)
┌ for i <- 1,n do
│ ┌ if i%2=0 then
│ │     a <- a-i*i
│ │ else
│ │     a <- a+i*i
│ └■
└■
 write a 
*)
open System
printf " a="
let a=uint32(Console.ReadLine())
printf " n="
let n=uint32(Console.ReadLine())
let rec forLoop (a:uint32) (n:uint32)=
    match n with
    | 0u -> a
    | _ -> match n%2u = 0u with
           | true -> forLoop (a-n*n) (n-1u)
           | false -> forLoop (a+n*n) (n-1u)

let res=forLoop a n
printfn "%i" res
