open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.create 10 0
let solutie p=
    p=k
let afiseaza p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""
let validare p=
    match p<=2 with
    | true -> true
    | false -> match (sol.[p-2]=0 && sol.[p-1]=0) with
               | false -> true
               | true -> sol.[p]<>0 
let rec backtracking p=
    for i in 0..n-1 do
        sol.[p] <- i 
        if (validare p) then
            if (solutie p) then
                afiseaza p
            else 
                backtracking (p+1)

let res=backtracking 1
