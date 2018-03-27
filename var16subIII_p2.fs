(*
    Given the set A={3,5,7}, generate all numbers with k digits 
    using only the elements af set A.
*)
open System
printf "Number of elements of set A n="
let n=Console.ReadLine() |> int
printf "Number of digits for generated numbers k="
let k= Console.ReadLine() |> int
let solution=Array.zeroCreate<int> 10
let validateSolution p=
    true
let isCompleteSolution p=
    p=k
let printSolution p=
    for i in 1..p do
        if solution.[i]=1 then printf "3"
        if solution.[i]=2 then printf "5"
        if solution.[i]=3 then printf "7"
    printfn ""

let rec backtracking p=
    for i in 1..n do
        solution.[p] <- i 
        if validateSolution p then
            if isCompleteSolution p then
                printSolution p
            else
                backtracking (p+1)

let res= backtracking 1