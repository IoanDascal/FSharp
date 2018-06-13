(*
    Given the adjacency matrix of a directed graph, find the longest
directed path betwwen two nodes.
Example: For the graph : 
         0 1 1 0 1 0
         0 0 0 0 1 0
         0 1 0 1 0 0
         0 0 0 0 1 0
         0 0 0 0 0 1
         0 0 0 0 0 0 
The longest directed path from 1 to 6 is : 1 3 4 5 6
*)

open System
printf "Enter the number of vertices n="
let n=int32(Console.ReadLine())
let adjacencyMatrix=[for i in 1..n do  
                         yield [for j in 1..n do  
                                    printf "mat[%i,%i]=" i j
                                    yield int32(Console.ReadLine())]]
printfn "The adjacency matrix is:"
for row in adjacencyMatrix do  
    printfn "%A" row
///Bellman-Ford algorithm works fine if there is no cycle on any 
/// directed path from source to destination.
let infinity=Int32.MaxValue
let costsMatrix=[for i in 0..n-1 do  
                    yield [for j in 0..n-1 do   
                               if i<>j then 
                                   if adjacencyMatrix.[i].[j]=0 then yield infinity
                                       else yield -1
                               else yield 0]]
printfn ""
printfn "The costs matrix is:"
for row in costsMatrix do  
    printfn "%A" row
let distances=Array.create<int32> n infinity
let predecessors=Array.zeroCreate<int32> n
printf "Enter the source vertex s="
let s=int32(Console.ReadLine())
printf "Enter the destination vertex d="
let d=int32(Console.ReadLine())
let BellmanFord source =
    Array.set distances source 0
    for i in 0..n-1 do
        predecessors.[i] <- source
    for i in 0..n-1 do
        for j in 0..n-1 do
            for k in 0..n-1 do
                if costsMatrix.[j].[k]<>infinity && distances.[k]>distances.[j]+costsMatrix.[j].[k] 
                    then
                        distances.[k] <- distances.[j]+costsMatrix.[j].[k]
                        predecessors.[k] <- j
    let pred=Array.map (fun x -> x+1) predecessors
    (pred,distances) 
let resBF=BellmanFord (s-1)

let rec longestPath source destination=
    [
        if destination<>source then
            yield destination
            let destination'=(fst resBF).[destination-1] 
            yield! longestPath source destination'
        else 
            yield destination
    ]
let path=longestPath s d   
printfn "The longest directed path from vertex %i to %i is %A." s d (List.rev path)
printfn "The length of the longest directed path is %i " (-1*(snd resBF).[d-1])