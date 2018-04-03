(*
 read n ( natural number)
 s <- 10
┌ while n>0 do
│┌ if n%10<s then
││    s <- n%10
││ else
││    s <- -1
│└■
│ n <- [n/10]
└■
  write s
*)
open System
printf " n="
let n=int(Console.ReadLine())
let rec whileLoop s n=
    match n with 
    |0 -> s
    | _ -> match n%10<s with
           | true -> whileLoop (n%10) (n/10)
           | false -> whileLoop -1 (n/10)

let res=whileLoop 10 n
printfn "%i" res