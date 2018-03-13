(*
    Generate all numbers of five digits using backtracking method.
    Numbers must have first digit 5, and digits must be in increasing order.
*)
open System
printf " n="       //Number of digits = 9
let n=int(Console.ReadLine())
printf " k="      //Number of digits in the generated numbers
let k=int(Console.ReadLine())
let sol=Array.create 10 0
let printSolution p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""

let validatePartialSolution p=
    match sol.[1] with
    | 5 -> sol.[p-1]<sol.[p]
    | _ -> false

let isCompleteSolution p=
    p=k

let rec backtracking p=
    for i in 1..n do
        sol.[p] <- i
        if (validatePartialSolution p) then
            if (isCompleteSolution p) then
                printSolution p
            else
                backtracking (p+1)

let res=backtracking 1