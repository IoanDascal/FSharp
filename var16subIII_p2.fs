open System
printf "Dati numar elemente multime n="
let n=Console.ReadLine() |> int
printf "Dati numarul de cifre ale numarului format k="
let k= Console.ReadLine() |> int
let sol=Array.zeroCreate<int> 10
let valid p=
    true
let solutie p=
    p=k
let afisare p=
    for i in 1..p do
        if sol.[i]=1 then printf "3"
        if sol.[i]=2 then printf "5"
        if sol.[i]=3 then printf "7"
    printfn ""

let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i 
        if valid p then
            if solutie p then
                afisare p
            else
                backtracking (p+1)

let res= backtracking 1