(*
    Generate all numbers with k digits from set {0,2,9}
*)
open System
printf "Enter the number of elements from set n="
let n=int(Console.ReadLine())
printf "Enter the number of elements from solution k="
let k=int(Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let validatePartialSolution p=
    not (p=1 && sol.[1]=1 )
let isCompleteSolution p=
    p=k
let printSolution p=
    for i in 1..p do
        if sol.[i]=1 then printf "0"
            else if sol.[i]=2 then printf "2"
                     else printf "9"
    printfn ""
let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if validatePartialSolution p then
            if isCompleteSolution p then
                printSolution p
                else
                    backtracking (p+1)

let res=backtracking 1