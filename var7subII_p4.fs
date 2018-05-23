(*
    Given the adjacency matrix of an ordered graph, write a function to 
calculate the number of all partial graphs that can be obtained from this
graph.
Example:
      0 1 0 1 0 1
      0 0 0 0 1 0
      0 0 0 0 0 0
      0 0 0 0 1 0
      0 0 0 0 0 1
      0 0 1 0 0 0
There are 127 partial graphs.
*)

open System
printf "Enter number of vertices n="
let n=int32(Console.ReadLine())
let adjacencyMatrix=[|for i in 1..n do
                          yield([|for j in 1..n do 
                                      printf "adjMat[%i,%i]=" i j
                                      yield(int32(Console.ReadLine()))|])|]
printfn "The adjacency matrix is :"
for line in adjacencyMatrix do
    printfn "%A" line
let arrayOfEdges=[|for i in 0..n-1 do  
                     for j in 0..n-1 do
                         if adjacencyMatrix.[i].[j]=1 then
                             yield (i+1,j+1)|]
///Use function nChooseK to generate all possible combinations
/// of k edges, from initial list of n edges.
let nChooseK arr k = 
    let rec choose low  =
        function
        |0 -> [[]]
        |i -> [for j=low to (Array.length arr)-1 do
                               for ks in choose (j+1) (i-1) do
                                   yield arr.[j] :: ks ]
    choose 0  k
let nrOfEdges=arrayOfEdges.Length
let rec allPartialListsOfEdges k nr=
    match k<nrOfEdges with
    | false -> nr  
    | true -> let partialListsWithKEdges=nChooseK arrayOfEdges (nrOfEdges-k)
              let nrOfPartialLists=partialListsWithKEdges.Length
              printf "%i " nrOfPartialLists
              allPartialListsOfEdges (k+1) (nr+nrOfPartialLists)
printfn "The number of partial graphs that can be obtained from the initial graph is : %i" ((allPartialListsOfEdges 1 0)+1)