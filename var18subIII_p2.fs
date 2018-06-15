(*
    Write a function to generate all arrays with k digits,
using digit 0 and digit 1. 
     - n=2 , because we are using only 0 and 1.
     - k is the number of digits from an array
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
printf "Enter k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 10
let validatePartialSolution p=
    true
let completeSolution p=
    p=k
let printSolution p=
    for i in 1..p do
        printf "%i" solution.[i]
    printfn ""
let rec backtracking p=
    for i in 0..n-1 do
        solution.[p] <- i
        if validatePartialSolution p then
            if completeSolution p then
                printSolution p
            else
                backtracking (p+1)
let res= backtracking 1