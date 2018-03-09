printf "Dati numarul de elemente ale mutimii n="
let n=int(System.Console.ReadLine())
printf "Dati numarul de elemente care compun solutia k="
let k=int(System.Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let validare p=
    not (p=1 && sol.[1]=1 )
let solutie p=
    p=k
let afisare p=
    for i in 1..p do
        if sol.[i]=1 then printf "0"
            else if sol.[i]=2 then printf "2"
                     else printf "9"
    printfn ""
let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if validare p then
            if solutie p then
                afisare p
                else
                    backtracking (p+1)

let res=backtracking 1