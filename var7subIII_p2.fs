(*
    Write a function that generates all numbers with k digits.
Each number must have different digits in increasing order.
Write all numbers with the last digit equal to 6.
*)
open System
printf "Enter number of digits n="
let n=int(Console.ReadLine())
printf "Enter number of digits from generated numbers k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 20
let completeSolution p=
    p=k && solution.[p]=6
let printSolution p = 
    for i in 1..p do
       printf "%i" solution.[i]
    printfn ""

let validatePartialSolution p=
    match p with
    | 1 -> true
    | _ -> solution.[p-1] < solution.[p]

let rec backtracking p =
    for i in 1..n do
        solution.[p] <- i
        if (validatePartialSolution p) then
            if (completeSolution p) then
                printSolution p 
            else
                backtracking (p+1)  

let res=backtracking 1 