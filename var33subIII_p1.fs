(*
    Using backtracking, generate in incresing order 
all numbers with k digts. The sum of digits must be equal to s.
*)
open System
printf "Enter the total number of digits (n=10) n="
let n=int(Console.ReadLine())
printf "Enter the number of digits in solution k="
let k=int(Console.ReadLine())
printf "Enter the sum of digits from solution s="
let s=int(Console.ReadLine())
let solution=Array.zeroCreate 15
let mutable sum=0
let printSolution p=
    if sum=s then for i in 1..p do
                      printf "%i" solution.[i]
                  printfn ""


let validatePartialSolution p=
    match p with
    | 1 -> solution.[p]<=s && solution.[p]>0
    | _ -> sum <- Array.sum solution.[1..p]
           sum<=s

let isCompleteSolution p=
    p=k

let rec backtracking p=
    for i in 0..n-1 do
        solution.[p] <- i
        if (validatePartialSolution p) then
            if (isCompleteSolution p) then
                printSolution p
            else
                backtracking (p+1)

let res= backtracking 1