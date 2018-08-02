(*
    Given an undirected graph with n vertices and m edges,
write a program to verify if a list of vertices is a Hamiltonian
path using the adjacency matrix.
Example: For n=7, m=10 and edges [1,3],[2,3],[3,4],[3,5],[5,4],[1,2],
         [2,5],[2,4],[6,7],[3,6]  
   - List (7,6,3,5,4,2,1) is a Hamiltonian path
   - List (1,2,3,4,5,6,7) is not a Hamiltonian path
*)

open System
printf "Enter the number of vertices n="
let n=int(Console.ReadLine())
printf "Enter the number of edges m="
let m=int(Console.ReadLine())
let adjacencyMatrix=Array2D.zeroCreate<int> (n+1) (n+1)
for i in 1..m do 
    printf "Enter x="
    let x=int(Console.ReadLine())
    printf "Enter y="
    let y=int(Console.ReadLine())
    adjacencyMatrix.[x,y] <- 1
    adjacencyMatrix.[y,x] <- 1
printfn "The adjacency matrix is :"
for i in 1..n do
    for j in 1..n do
        printf "%i  " adjacencyMatrix.[i,j]
    printfn ""

printf "Enter the number of vertices from the list nr="
let nr=int(Console.ReadLine())
let path=[for i in 1..nr do 
               yield(printf "path[%i]=" i
                     int(Console.ReadLine()))]
let rez=
    let rec loop i=
        match i<(nr-1) with
        | false -> i
        | true -> match adjacencyMatrix.[path.[i],path.[i+1]]=1 with     
                  | false -> i
                  | true -> loop (i+1)
    loop 0
printfn "rez=%i" rez
if rez<nr-1 then printfn "The list is not a path in the graph."
    else
        let distinct=List.distinct path
        if distinct.Length<n then printfn "The path does not contain all vertices from the graph."
            else
                printfn "This is a Hamiltonian path."

