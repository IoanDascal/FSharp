(*
    Given
*)

type Edge=int*int
type Graph=int list*Edge list
type AdjacencyMatrix=int array array
let graph=([1;2;3;4;5;6;7;8],[(1,2);(1,3);(1,4);(2,3);(2,5);(2,6);(3,5);(4,6);(5,6)])
let graphToAdjacencyMatrix ((nodes,edges):Graph):AdjacencyMatrix=
    let adjacencyMatrix=[|for i in 0..(nodes.Length+1) do
                              yield([|for j in 0..(nodes.Length+1) do
                                          yield 0|])|]
    let rec addEdge edges=
        match edges with
        | [] -> ()
        | hd::tail -> adjacencyMatrix.[fst hd].[snd hd] <- 1
                      adjacencyMatrix.[snd hd].[fst hd] <- 1
                      addEdge tail  
    addEdge edges
    adjacencyMatrix
let n=(fst graph).Length
let adjacencyMatrix=graphToAdjacencyMatrix graph
printfn "The adjacency matrix reprezentation of the graph is:"
for i in 1..n do
    for j in 1..n do
        printf "%3i" adjacencyMatrix.[i].[j]
    printfn ""
let degrees=[|for i in 1..n do
                  yield(Array.sum adjacencyMatrix.[i])|]
printf "Degrees for each vertex are : "
printfn "%A" degrees
let maximumDegree=Array.max degrees
printf "The nodes with the maximum degree %i are : " maximumDegree
degrees |> Array.iteri (fun i x -> if x=maximumDegree then printf "%i" (i+1))
printfn "" 
let minimumDegree=Array.min degrees
printf "The nodes with the minimum degree %i are : " minimumDegree
degrees |> Array.iteri (fun i x -> if x=minimumDegree then printf "%i " (i+1))
printfn "" 
let visited=Array.zeroCreate<bool> (n+1)
let traversalArray=Array.zeroCreate<int> n
let rec recursiveDFS i k=
    traversalArray.[k] <- i
    visited.[i] <- true
    for j in 1..n do
        if visited.[j]=false && adjacencyMatrix.[i].[j]=1 then recursiveDFS j (k+1) 
recursiveDFS 1 0
printfn "%A" traversalArray
printfn ""
Array.fill visited 0 (n+1) false
let rec connectedComponents start numberOfConnectedComponents=
    match start>n with
    | true -> numberOfConnectedComponents
    | false -> match visited.[start] with
               | false -> Array.fill traversalArray 0 n 0
                          recursiveDFS start 0
                          printfn "%A" traversalArray
                          connectedComponents (start+1) (numberOfConnectedComponents+1)
               | true -> connectedComponents (start+1) numberOfConnectedComponents  
let numberOfConnectedComponents=connectedComponents 1 0
printfn "The number of connected components is : %i" numberOfConnectedComponents

//    Version 1
//       https://www.youtube.com/watch?v=dQr4wZCiJJ4


let hamiltonianCycle=Array.zeroCreate<int> (n+2)
printf "Enter the start vertex :"
let start=int(System.Console.ReadLine())
hamiltonianCycle.[1] <- start
let rec nextVertex k=
    hamiltonianCycle.[k] <- (hamiltonianCycle.[k]+1)%(n+1)
    match hamiltonianCycle.[k] with
    | 0 -> ()
    | _ -> match adjacencyMatrix.[hamiltonianCycle.[k-1]].[hamiltonianCycle.[k]] with
           | 0 -> nextVertex k
           | _ -> let rec vertexNumber i=
                      match i<k with
                      | false -> i
                      | true -> match hamiltonianCycle.[i]=hamiltonianCycle.[k] with
                                | true -> i
                                | false -> vertexNumber (i+1)
                  match k=(vertexNumber 1) with
                  | false -> nextVertex k
                  | true -> if k<n || (k=n && adjacencyMatrix.[hamiltonianCycle.[n]].[hamiltonianCycle.[1]]=1) then ()
                            else (nextVertex k)
printfn "Version 1:"
let rec getHamiltonianCycle k=
    nextVertex k
    match hamiltonianCycle.[k] with
    | 0 -> printfn "Solution does not exist!"
    | _ -> match k=n with  
           | true -> printfn "Hamiltonian cycle: %A" hamiltonianCycle
           | false -> getHamiltonianCycle (k+1)

getHamiltonianCycle 2

//    Vewrsion 2
//       https://www.geeksforgeeks.org/hamiltonian-cycle-backtracking-6/     

///<summary> A utility function to check if the vertex v can be added at index 'pos' in the Hamiltonian Cycle constructed so far</summary>  
/// <returns> True or false</returns>
let isSafe v pos=
    //Check if this vertex is an adjacent vertex of the previously added vertex.
    match adjacencyMatrix.[hamiltonianCycle.[pos-1]].[v] with
    | 0 -> false
    | _ -> // Check if the vertex has already been included.
           let included=Array.tryFind (fun elem -> elem=v) hamiltonianCycle.[..(pos-1)]
           if included.IsSome then false else true

///<summary> A utility function to solve hamiltonian cycle problem</summary>  
/// <returns> True or false</returns>
let rec getHamiltonianCycle1 pos=
    // base case: If all vertices are included in Hamiltonian Cycle 
    match pos=n with
    | true -> // And if there is an edge from the last included vertex to the first vertex
              if adjacencyMatrix.[hamiltonianCycle.[n]].[hamiltonianCycle.[1]]=1 then true else false
    | false -> // Try different vertices as a next candidate in Hamiltonian Cycle.
               let rec tryAnotherV v= 
                   match v>n with
                   | false -> // Check if vertex v can be added to Hamiltonian Cycle
                              match (isSafe v pos) with
                              | true -> hamiltonianCycle.[pos] <- v
                                        match (getHamiltonianCycle1 (pos+1)) with
                                        | true -> true
                                        | false -> // If adding vertex v doesn't lead to a solution, then remove it
                                                   hamiltonianCycle.[pos] <- 0
                                                   tryAnotherV (v+1)
                              | false -> tryAnotherV (v+1) 
                    | true -> false
               tryAnotherV 1
printfn "Version 2:"
if (getHamiltonianCycle1 1) then printfn "%A" hamiltonianCycle
    else  
        printfn "Solution does not exist!"
