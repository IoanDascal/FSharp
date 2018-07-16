(*
    Generate all numbers with k digits from set {0,2,9}.
If k=4, how many numbers are divisible by 100.
*)
open System
printf "Enter the number of elements from set n="
let n=int(Console.ReadLine())
printf "Enter the number of elements from solution k="
let nrDiv100=ref 0
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
    if sol.[p]=1 && sol.[p-1]=1 then nrDiv100:=nrDiv100.Value+1
let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if validatePartialSolution p then
            if isCompleteSolution p then
                printSolution p
                else
                    backtracking (p+1)

let res=backtracking 1
printfn "There are %i numbers divisible by 100" nrDiv100.Value