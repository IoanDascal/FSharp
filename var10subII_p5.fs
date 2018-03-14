(*
    Construct a matrix that contains the squares of the first n*p even numbers
*)

open System
printf "Number of rows n="
let n=int(Console.ReadLine())
printf "Number of columns p="
let p=int(Console.ReadLine())
let mutable x=0
let matrix=[|for i in 0..n-1 do
                  yield [|for j in 0..p-1 do 
                              yield (pown x 2);x<-x+2|]|]             

for i in 0..n-1 do
    for j in 0..p-1 do
        printf "%8i " matrix.[i].[j]
    printfn ""
