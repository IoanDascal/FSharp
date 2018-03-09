printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let mutable nrSolutii=0
let valid p=
    if p=1 then true
        else
            let distinct=Array.distinct sol.[1..p]
            distinct.Length=p
let afisare p=
    for i in 1..p do
        if sol.[i]=1 && sol.[i-1]=4 || sol.[i]=4 && sol.[i-1]=1 then
            nrSolutii <- nrSolutii+1
            for j in 1..p do
                if sol.[j]=1 then printf "I"
                if sol.[j]=2 then printf "N"
                if sol.[j]=3 then printf "F"
                if sol.[j]=4 then printf "O"
            printfn ""
let solutie p=
    p=k
let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if valid p then
            if solutie p then
                afisare p
                else 
                    backtracking (p+1)

let res=backtracking 1
printfn "Nr sol=%i" nrSolutii