(*
    Given an undirected graph with 8 vertices and edges:
    [1,2],[1,6], [1,7], [2,3], [2,6], [3,6], [3,4], [4,5], [4,8], [5,6], [7,8].  
    Which is the minimum degree of a vertex from the graph? 
    Which are the nodes with the munimum degree?
*)
open System
printf "Enter the number of nodes n="
let n=int(Console.ReadLine())
let adjacencyMatrix=Array2D.zeroCreate<int> (n+1) (n+1)
printf "Enter the number of edges m="
let m=int(Console.ReadLine())
for i in 1..m do
    printf " x="
    let x=int(Console.ReadLine())
    printf " y="
    let y=int(Console.ReadLine())
    adjacencyMatrix.[x,y] <- 1
    adjacencyMatrix.[y,x] <- 1

printfn "The adjacency-matrix representation is:"
for i in 1..n do
    for j in 1..n do
        printf "%i " adjacencyMatrix.[i,j]
    printfn ""

let degrees=[for i in 1..n do
               yield (Array.sum adjacencyMatrix.[i,*])] 
printfn "The degree for each node  = %A" degrees
let minimumDegree=List.min degrees
printfn "The minimum degree is =%i" minimumDegree

printfn "The vertices with the minimum degree are :"
degrees |> List.iteri (fun i x -> if x=minimumDegree then printf "%i " (i+1) else ())

