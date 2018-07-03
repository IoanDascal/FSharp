(*
    A programme read a value for n (n=9 , maximum digit) and a
value for k. It generate all combinations of k digits according to
next rules:
 - all combinations starts and ends with digit 0;
 - the absolute value for the differemce between two neighbor digits
is 1.
*)
open System
printf "Enter the number of digits n="
let n=int(Console.ReadLine())
printf "Enter the number of digits from solution k="
let k=int(Console.ReadLine())
let sol=Array.zeroCreate<int> 10
let validatePartialSolution p=
    if p=1 then 
        sol.[1]=0
    else if p<k && (abs (sol.[p]- sol.[p-1]))=1 then true
             else p=k && (abs (sol.[p]- sol.[p-1]))=1 && sol.[p]=0
let printSolution p=
    for i in 1..p do
        printf "%i" sol.[i]
    printfn ""
let isCompleteSolution p=
    p=k
let rec backtracking p=
    for i in 0..n do
        sol.[p] <- i
        if (validatePartialSolution p) then
            if (isCompleteSolution p) then
                printSolution p
                else 
                    backtracking (p+1)

let res = backtracking 1
printfn ""