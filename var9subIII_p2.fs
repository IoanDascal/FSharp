open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.create 10 0
let afisare p=
    let suma=Array.sum sol
    match suma with
    | 12 -> for i in 1..p do
                printf "%i" sol.[i]
            printfn ""
    | _ -> printf ""

let validare p=
    match p with
    | 1 -> true
    | _ -> let suma=Array.sum sol.[1..p]
           (sol.[p-1]<sol.[p]) && (sol.[p-1]%2<>sol.[p]%2) && (suma<=12)

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

let res= backtracking 1