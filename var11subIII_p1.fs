(*
   Generate all possible sequences of five digits that contains  digits of  0 or 1. 
   Each sequence must contain less than three successive digits of 0.
   n=2  -> number of digits , 0 and 1
   k=5  -> number of digit in a sequence
*)
open System
printf " n="
let n=int(Console.ReadLine())
printf " k="
let k=int(Console.ReadLine())
let solution=Array.create 10 0
let  completeSolution p=
    p=k
let printSolution p=
    for i in 1..p do
        printf "%i" solution.[i]
    printfn ""
let validatePartialSolution p=
    match p<=2 with
    | true -> true
    | false -> match (solution.[p-2]=0 && solution.[p-1]=0) with
               | false -> true
               | true -> solution.[p]<>0 
let rec backtracking p=
    for i in 0..n-1 do
        solution.[p] <- i 
        if (validatePartialSolution p) then
            if (completeSolution p) then
                printSolution p
            else 
                backtracking (p+1)

let res=backtracking 1
