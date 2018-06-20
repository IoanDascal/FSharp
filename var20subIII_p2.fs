(*
    Write a function to generate all numbers with k digits in decreasing order.
Every number must have distinct digits in increasing order and two consecutive 
digits must not be even.
*)
open System
printf "Enter the number of available digits n="
let n=int(Console.ReadLine())
printf "Enter the number of digits from solution k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 10
let validatePartialSolution p=
    match p with
    | 1 -> true
    | _ -> solution.[p]>solution.[p-1] && not (solution.[p]%2=0 && solution.[p-1]%2=0) 
let isCompleteSolution p=
    p=k
let printSolution p=
    if solution.[1]<>0 then 
        for i in 1..p do
            printf "%i" solution.[i]
        printf "    "

let rec backtracking p=
    for i in n.. -1..0 do
        solution.[p] <- i 
        if validatePartialSolution p then
            if isCompleteSolution p then
                printSolution p
            else
                backtracking (p+1)

let res=backtracking 1
        