(*
    Using backtracking, generate in incresing order 
all numbers with three digts. Digits form every number 
must be in incresing order; consecutive digits must have 
different parities and their sum mut be equal to 12.
*)
open System
printf "Enter the number of digits n="
let n=int(Console.ReadLine())
printf "Enter the number of digits in solution k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate 10
let printSolution p=
    let sum=Array.sum solution
    match sum with
    | 12 -> for i in 1..p do
                printf "%i" solution.[i]
            printfn ""
    | _ -> printf ""

let validatePartialSolution p=
    match p with
    | 1 -> true
    | _ -> let sum=Array.sum solution.[1..p]
           (solution.[p-1]<solution.[p]) && (solution.[p-1]%2<>solution.[p]%2) && (sum<=12)

let isCompleteSolution p=
    p=k

let rec backtracking p=
    for i in 1..n do
        solution.[p] <- i
        if (validatePartialSolution p) then
            if (isCompleteSolution p) then
                printSolution p
            else
                backtracking (p+1)

let res= backtracking 1