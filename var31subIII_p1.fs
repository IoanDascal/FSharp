(*
    Using the set {0,1,2,...,n} generate all numbers 
with the sum of digits equal to s.
*)

open System
printf "Enter the number of digits n (n<10) ="
let n=int(Console.ReadLine())
printf "Enter the sum of digits s="
let s=int(Console.ReadLine())
let solution=Array.zeroCreate<int> 10

let validatePartialSolution p=
    p<=n && solution.[1]<>0
let isCompleteSolution p=
    (Array.sum solution.[1..p])=s
let printSolution p=
    for i in 1..p do  
        printf "%i" solution.[i]
    printf "  "

let rec backtracking p=
    for i in 0..n-1 do  
        solution.[p] <- i   
        if validatePartialSolution p then 
            if isCompleteSolution p then  
                printSolution p
                else    
                    backtracking (p+1)

let res=backtracking 1