(*
    Write a function to generate all numbers with three digits.
Digits must be in increasing order and consecutive digits must 
be of different parities.
*)
open System
let sol=Array.create 10 0
printf "Enter total number of digits n="
let n= int(Console.ReadLine())
printf "Enter number of digits from the solution k="
let k=int(Console.ReadLine())
let validatePartialSolution p=
    match p>1 with
    | false -> true
    | true -> (sol.[p-1] < sol.[p]) && (sol.[p-1]%2 <> sol.[p]%2)
let completeSolution p=
    p=k

let printSolution p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""

let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if (validatePartialSolution p) then
            if (completeSolution p) then
                printSolution p
                else 
                    backtracking (p+1)

let res=backtracking 1
