(*
    Write a function that generates all numbers with k digits.
Each number must have different digits, and consecutive digits 
must have different parity.
*)
open System
printf "Enter number of digits n="
let n=int(Console.ReadLine())
printf "Enter number of digits from generated numbers k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 10
let completeSolution p=
    p=k-1
let printSolution p = 
    for i in 0..p do
       printf "%i" solution.[i]
    printfn ""

let validatePartialSolution p=
    match p with
    | 0 -> solution.[0]<>0 
    | _ -> (solution.[p-1]%2 <> solution.[p]%2) && not (Array.contains solution.[p] solution.[..p-1])

let rec backtracking p =
    for i in 0..n-1 do
        solution.[p] <- i
        if (validatePartialSolution p) then
            if (completeSolution p) then
                printSolution p 
            else
                backtracking (p+1)  

let res=backtracking 0  
