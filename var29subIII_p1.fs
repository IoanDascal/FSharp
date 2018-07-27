(*
    Genrate all permutations of the set {'I','N','F','O'}. In how many
permutations there are two vowels in consecutive positions.
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
printf "Enter k="
let k=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 10
let mutable nrOfConsecutiveVowels=0
let validateSolution p=
    if p=1 then true
        else
            let distinct=Array.distinct solution.[1..p]
            distinct.Length=p
let printSolution p=
    for i in 1..p do
        if solution.[i]=1 && solution.[i-1]=4 || solution.[i]=4 && solution.[i-1]=1 then
            nrOfConsecutiveVowels <- nrOfConsecutiveVowels+1
            for j in 1..p do
                if solution.[j]=1 then printf "I"
                if solution.[j]=2 then printf "N"
                if solution.[j]=3 then printf "F"
                if solution.[j]=4 then printf "O"
            printfn ""
let completeSolution p=
    p=k
let rec backtracking p=
    for i in 1..n do
        solution.[p] <- i
        if validateSolution p then
            if completeSolution p then
                printSolution p
                else 
                    backtracking (p+1)

let res=backtracking 1
printfn "The number of permutations with two consecutive vowels is=%i" nrOfConsecutiveVowels