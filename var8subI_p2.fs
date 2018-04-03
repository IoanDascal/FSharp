(*
 read n,k ( natural numbers n>0,k>0)
 nr <- 0
 p <- 1
┌ while n≠0 and k≠0 do
│┌ if n%2=0 then
││    nr <- nr+ n%10*p
││    p <- p*10
││ else
││    k <-  k-1
│└■
│  n <- [n/10]
└■
 write nr 
*)
open System
printf " n="
let n=int(Console.ReadLine())
printf " k="
let k=int(Console.ReadLine())
let rec whileLoop n k p nr=
    match n<>0 && k<>0 with
    | false -> nr
    | true -> match n%2=0 with
              | true -> whileLoop (n/10) k (p*10) (nr+n%10*p)
              | false -> whileLoop (n/10) (k-1) p nr 

let res = whileLoop n k 1 0
printfn "%i" res 