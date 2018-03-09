open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.create 10 0
let afisare p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""

let validare p=
    match sol.[1] with
    | 5 -> sol.[p-1]<sol.[p]
    | _ -> false

let solutie p=
    p=k

let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if (validare p) then
            if (solutie p) then
                afisare p
            else
                backtracking (p+1)

let res=backtracking 1