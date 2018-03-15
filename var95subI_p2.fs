(*
 x <- 0 
 read n,k ( natural numbers n>0 , k>0) 
┌ while n ≠ 0 do
│┌ if n%10<k then 
││   x <- x*10 + n%10 
│└■
│ n <- [n/10] 
└■
 write x 
*)

open System
printf "n="
let n=uint32(Console.ReadLine())
printf "k="
let k=uint32(Console.ReadLine())
let rec whileLoop n x =
    match n>0u with
    | false -> x
    | true -> match n%10u<k with
              | false -> whileLoop (n/10u) x
              | true -> whileLoop (n/10u) (x*10u+n%10u)
let res=whileLoop n 0u
printfn "%u" res
