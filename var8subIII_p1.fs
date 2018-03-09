open System
let sol=Array.create 10 0
printf "Dati n="
let n= int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let validare p=
    match p>1 with
    | false -> true
    | true -> (sol.[p-1] < sol.[p]) && (sol.[p-1]%2 <> sol.[p]%2)
let solutie p=
    p=k

let afisare p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""

let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if (validare p) then
            if (solutie p) then
                afisare p
                else 
                    backtracking (p+1)

let res=backtracking 1
