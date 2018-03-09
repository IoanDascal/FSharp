printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let valid p=
    sol.[1]<>1
let solutie p=
    p=k

let afisare p=
    for i in 1..p do
        if sol.[i]=1 then printf "0"
        if sol.[i]=2 then printf "4"
        if sol.[i]=3 then printf "8"
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