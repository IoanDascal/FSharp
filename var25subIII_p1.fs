//open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let validare p=
    if p=1 then 
        sol.[1]=0
    else if p<k && (abs (sol.[p]- sol.[p-1]))=1 then true
             else p=k && (abs (sol.[p]- sol.[p-1]))=1 && sol.[p]=0
let afisare p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""
let solutie p=
    p=k
let rec backtracking p=
    for i in 0..n do
        sol.[p] <- i
        if (validare p) then
            if (solutie p) then
                afisare p
                else 
                    backtracking (p+1)

let res = backtracking 1
printfn ""