open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let sol=Array.create<int> 10 0
let valid p=
    not (Array.exists (fun x -> x=sol.[p]) sol.[1..p-1])
let solutie p=
    p=k
let afisare p=
    for i in 1..p do
        match sol.[i] with
        | 1 -> printf "%c" 'f'
        | 2 -> printf "%c" 'i'
        | 3 -> printf "%c" 'n'
        | 4 -> printf "%c" 'o'
        | _ -> printf "Eroare"
    printfn ""

let rec backtracking p=
    for i in 1..n do
        sol.[p]<-i
        if valid p then
            if solutie p then
                afisare p
                else
                    backtracking (p+1)

let res=backtracking 1