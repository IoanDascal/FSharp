(*
Scrieti programul C/C++ corespunzator algoritmului dat. 

citeste n (numar natural)
z <- 0  
p <- 1 
┌ cat timp n>0 executa
│  c <- n%10  
│  n <- [n/10] 
│┌ daca c%3=0 atunci 
││   z <- z+p*(9-c) 
││   p <- p*10 
│└■
└■
scrie z  
*)
open System
printf "Dati un numar intreg n="
let n=int32(Console.ReadLine())
printfn "n =%i" n

let rec sumCifre z n p=
    match n with
    | 0 -> z
    |_ -> match (n%10)%3=0 with
          | true -> sumCifre (z+p*(9-n%10)) (n/10) (p*10)
          | false -> sumCifre z (n/10) p

let res=sumCifre 0 n 1
printfn "Suma cifre=%i" res