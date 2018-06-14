(*
    Given the adjacency matrix of a directed graph, find for how 
many vertices the outdegree is an odd number.
*)

open System
printf "Enter the number of vertices n="
let n=int32(Console.ReadLine())
let adjacencyMatrix=[for i in 1..n do   
                         yield [for j in 1..n do
                                    printf "mat[%i,%i]=" i j
                                    yield int32(Console.ReadLine())]]
printfn "The adjacency matrix is :"
for row in adjacencyMatrix do
    printfn "%A" row
let outdegrees=[for i in 0..n-1 do
                    yield (List.sum adjacencyMatrix.[i])]
let outdegreesType=List.countBy (fun x -> if x%2=0 then "even" else "odd") outdegrees
printfn "%A" outdegreesType
printfn "The number of vertices with outdegree an odd number is :"
if fst outdegreesType.[0]="odd" then printfn "%i" (snd outdegreesType.[0])
    else
        printfn "%i" (snd outdegreesType.[1])