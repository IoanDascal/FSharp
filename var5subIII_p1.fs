(*
    Using the digits from set {1,2,3,4,5,6,7,8} write a function
that generates all numbers with four digits that starts with
digit 2 and finishes with digit 7. Digits from each number 
must be in increasing order.
*)

open System
printf "Enter number of elements from a set n="
let n=int32(Console.ReadLine())
printf "Enter number of elements from solution k="
let k=int32(Console.ReadLine())
let solution=Array.create 10 0
let validatePartialSolution p=
    match p with
    | 1 -> solution.[1]=2
    | _ -> solution.[p] > solution.[p-1]
let completeSolution p=
    p=k
let printSolution p=
    if solution.[p]=7 then
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