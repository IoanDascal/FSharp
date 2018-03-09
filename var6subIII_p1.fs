open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.create<int> 10 0
let solutie p=
    p=k-1
let afisare p=
    for i in 0..p do
        printf "%i" sol.[i]
    printfn ""

let valid p=
    match p with
    | 0 -> sol.[0]<>0 
    | _ -> (sol.[p-1]%2 <> sol.[p]%2) && not (Array.contains sol.[p] sol.[..p-1])

let rec backtracking p=
    for i in 0..n-1 do
        sol.[p] <- i
        if (valid p) then
            if (solutie p) then
                (afisare p)
                else
                    backtracking (p+1)

let res=backtracking 0
