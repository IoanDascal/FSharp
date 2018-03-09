open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let distincte p=not (Array.exists (fun x -> x=sol.[p]) sol.[1..p-1] )
let valid p=
    match p with
    | 1 -> true
    | _ -> (distincte p) && not (sol.[p]%2=0 && sol.[p-1]%2=0) 
let solutie p=
    p=k
let afisare p=
    if sol.[1]<>0 then 
        for i in 1..p do
            printf "%i" sol.[i]
        printf "    "

let rec backtracking p=
    for i in 0..n do
        sol.[p] <- i 
        if valid p then
            if solutie p then
                afisare p
            else
                backtracking (p+1)

let res=backtracking 1
        