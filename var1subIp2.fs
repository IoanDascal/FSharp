(*
read n ( natural number)
z <- 0  
p <- 1 
┌ while n>0 do
│  c <- n%10  
│  n <- [n/10] 
│┌ if c%3=0 then 
││   z <- z+p*(9-c) 
││   p <- p*10 
│└■
└■
write z  
*)
open System
printf " n="
let n=int32(Console.ReadLine())
printfn "n =%i" n

let rec whileLoop z n p=
    match n with
    | 0 -> z
    |_ -> match (n%10)%3=0 with
          | true -> whileLoop (z+p*(9-n%10)) (n/10) (p*10)
          | false -> whileLoop z (n/10) p

let res=whileLoop 0 n 1
printfn "Sum of digits =%i" res