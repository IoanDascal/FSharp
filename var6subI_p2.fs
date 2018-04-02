(*
 read n ( natural number)
 s <- -1
┌ while n>0 do
│┌ if n%10>s then
││    s <- n%10
││ else
││    s <- 11
│└■
│ n <- [n/10]
└■
 write s 
*)

open System
printf "n="
let n=int32(Console.ReadLine())
let rec whileLoop n s=
    match n>0 with
    | false -> s
    | true -> whileLoop (n/10) (if n%10>s then (n%10) else 11)

let res=whileLoop n -1
printfn "%i" res
