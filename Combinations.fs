(*
    Computes the combinations without repetitions with
k elements from a set of n elements.
*)
open System
printf "Enter number of elements from a set n="
let n=int32(Console.ReadLine())
printf "Enter number of elements to combine k="
let k=int32(Console.ReadLine())
let solution=Array.create 10 0
let validatePartialSolution p=
    if p=1 then true else solution.[p-1]<solution.[p]
let completeSolution p=
    p=k

let printSolution p=
    for i in 1..p do
        printf "%i" solution.[i]
    printfn "" 
let rec backtracking p=
    for i in 1..n do
        solution.[p] <- i
        if (validatePartialSolution p) then
            if (completeSolution p) then
                printSolution p
                else
                    backtracking (p+1)

let rez=backtracking 1