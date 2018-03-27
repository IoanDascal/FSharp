(*
    Generate all permutations of word "info" using backtracking.
    The first three solutions are : fino, fion, fnio.
    n - number of letters of one word,
    k - number of letters from one solution.
*)
open System
printf " n="
let n=int(Console.ReadLine())
printf " k="
let k=int(Console.ReadLine())
let solution=Array.create<int> 10 0
let validateSolution p=
    not (Array.exists (fun x -> x=solution.[p]) solution.[1..p-1])
let isCompleteSolution p=
    p=k
let printSolution p=
    for i in 1..p do
        match solution.[i] with
        | 1 -> printf "%c" 'f'
        | 2 -> printf "%c" 'i'
        | 3 -> printf "%c" 'n'
        | 4 -> printf "%c" 'o'
        | _ -> printf "Error"
    printfn ""

let rec backtracking p=
    for i in 1..n do
        solution.[p]<-i
        if validateSolution p then
            if isCompleteSolution p then
                printSolution p
                else
                    backtracking (p+1)

let res=backtracking 1