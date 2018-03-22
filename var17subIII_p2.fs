(*
    Generate all numbers of k digits from n digits.
    The digits from each number must be in increasing order.
*)
open System
printf "n="
let n=Console.ReadLine() |> int
printf "k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 10
let validatePartialSolution p=
    match p with 
    | 1 -> true
    | _ -> solution.[p]>solution.[p-1]
let isCompleteSolution p=
    p=k

let printSolution p=
    for i in 1..p do
        printf "%i" solution.[i]
    printfn ""
let rec backtracking p=
    for i in 1..n do
        solution.[p] <- i
        if validatePartialSolution p then
            if isCompleteSolution p then
                printSolution p
                else 
                    backtracking (p+1)
let res=backtracking 1