open System
printf "Dati n="
let n=int32(System.Console.ReadLine())
printf "Dati k="
let k=int32(System.Console.ReadLine())
let v=Array.create 10 0
let validare p=
    true

let solutie p=
    p=k

let afisare p=
    for i in 1..p do
        printf "%i" v.[i]
    printfn "" 
let rec backtracking p=
    for i in 1..n do
        v.[p] <- i
        if (validare p) then
            if (solutie p) then
                afisare p
                else
                    backtracking (p+1)

let rez=backtracking 1