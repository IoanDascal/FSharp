(*
    Generate all possible numbers with k digits from set {0,4,8}.
Example: For n=3, k=2 ----> 40,44,48,80,84,88
*)
open System
printf "Enter the number of elements from the set n="
let n=int(Console.ReadLine())
printf "Enter the number of elements from solution k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 10
let validatePartialSolution p=
    solution.[1]<>1
let isCompleteSolution p=
    p=k

let printSolution p=
    for i in 1..p do
        if solution.[i]=1 then printf "0"
        if solution.[i]=2 then printf "4"
        if solution.[i]=3 then printf "8"
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