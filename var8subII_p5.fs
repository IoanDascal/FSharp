(*
    Generate a matrix in which elements are squares
of odd numbers in increasing order.
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
printf "Enter p="
let p=int(Console.ReadLine())
let mutable odd=1
let matrix=[for i in 1..n do 
               yield [for j in 1..p do yield (pown odd 2);odd <- odd+2]]
for el in matrix do   
    printfn "%A" el