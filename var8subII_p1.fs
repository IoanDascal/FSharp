(*
    Given a directed graph g, write a function to calculate
the indegree and the outdegree for each vertex. For how many 
vertices the outdegree is greather than the indegree.
*)

open System
type 'a Edge='a*'a
type 'a Graph='a list*'a Edge list
type 'a Node='a*'a list
type 'a AdjacencyList='a Node list
printf "Enter the number of vertices n="
let n=int32(Console.ReadLine())
printf "Enter the number of edges m="
let m=int32(Console.ReadLine())
let vertices=[1..n]
printfn "Enter the edges :"
let edges=[for i in 1..m do 
               printf "Enter node 1 of edge %i:" i
               let node1=int32(Console.ReadLine())
               printf "Enter node 2 of edge %i:" i
               let node2=int32(Console.ReadLine())
               yield (node1,node2)]
let g=(vertices,edges)
let graphToAdjacencyList ((vertices,edges):'a Graph):'a AdjacencyList=
    let nodesMap=vertices |> List.map (fun x -> x,[]) |> Map.ofList
    (nodesMap,edges)
    ||> List.fold (fun map (a,b) -> map |> Map.add a (b::map.[a]))
    |> Map.toList
let adjacencyList=graphToAdjacencyList g
for item in adjacencyList do
    printfn "%A" item

let outdegrees=[for i in 0..adjacencyList.Length-1 do 
                    yield (snd adjacencyList.[i]).Length]
printfn "%A" outdegrees
let indegreeOfNode node (adjList:AdjacencyList<int>)=
    let rec countForNode count nr=
        match nr=n with
        | true -> count 
        | false -> let listContain=List.contains node (snd adjList.[nr])
                   match listContain with
                   | true -> countForNode (count+1) (nr+1)
                   | false -> countForNode count (nr+1)
    countForNode 0 0
let indegrees=[for i in 1..n do  
                   yield (indegreeOfNode i adjacencyList)]   
printfn "%A" indegrees
let countGreatestOutdegrees list1 list2 = List.fold2 (fun acc elem1 elem2 ->
                                              acc + (if elem1 > elem2 then 1 else 0)) 0 list1 list2

let count = countGreatestOutdegrees outdegrees indegrees
printfn "The number of nodes with outdegree greather than the indegree is  %d." count