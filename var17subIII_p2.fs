open System
printf "Dati n="
let n=Console.ReadLine() |> int
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let valid p=
    match p with 
    | 1 -> true
    | _ -> sol.[p]>sol.[p-1]
let solutie p=
    p=k

let afisare p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""
let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if valid p then
            if solutie p then
                afisare p
                else 
                    backtracking (p+1)
let res=backtracking 1