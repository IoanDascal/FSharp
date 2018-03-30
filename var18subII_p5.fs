(*
    Generate a matrix in which each element from an odd
    row is equal to the number of his column, and all
    elements from an even row are equals to the number 
    of their row.
*)
open System
printf " n="
let n=int(Console.ReadLine())
let matrix=[for i in 1..n do
                 yield ([for j in 1..n do
                            match i%2=0 with
                            | true -> yield j
                            | false -> yield i])]
for line in matrix do
    printfn "%A" line