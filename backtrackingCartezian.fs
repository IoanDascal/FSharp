(*
    Computes the cartesian product of k sets.
    Each set contains n elements.
*)
open System
printf "n="
let n=int32(Console.ReadLine())
printf "k="
let k=int32(Console.ReadLine())
let v=Array.create 10 0
let validatePartialSolution p=
    true

let completeSolution p=
    p=k

let printSolution p=
    for i in 1..p do
        printf "%i" v.[i]
    printfn "" 
let rec backtracking p=
    for i in 1..n do
        v.[p] <- i
        if (validatePartialSolution p) then
            if (completeSolution p) then
                printSolution p
                else
                    backtracking (p+1)

let rez=backtracking 1