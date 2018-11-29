(*

          Eulerian Cycle

An undirected graph has Eulerian cycle if following two conditions are true.
    a) All vertices with non-zero degree are connected. We don’t care about vertices with 
zero degree because they don’t belong to Eulerian Cycle or Path (we only consider all edges).
    b) All vertices have even degree.

          Eulerian Path

An undirected graph has Eulerian Path if following two conditions are true.
    a) Same as condition (a) for Eulerian Cycle
    b) If two vertices have odd degree and all other vertices have even degree. 
Note that only one vertex with odd degree is not possible in an undirected graph 
(sum of all degrees is always even in an undirected graph)

Note that a graph with no edges is considered Eulerian because there are no edges to traverse.
*)

open System
open System.Drawing
type 'a Edge='a*'a
type 'a Graph='a list*'a Edge list
type 'a Node='a*'a list
type 'a AdjacencyList='a Node list
let graphToAdjacencyList ((nodes,edges):'a Graph):'a AdjacencyList=
    let nodesMap=nodes |> List.map (fun n -> n,[]) |> Map.ofList
    (nodesMap,edges) ||> List.fold (fun map (a,b) -> map |> Map.add a (b::map.[a]) |> Map.add b (a::map.[b]))
                     |> Map.toList
printf "Enter the number of vertices n="
let n=int(Console.ReadLine())
printf "Enter the number of edges m="
let m=int(Console.ReadLine())
let edges=[for i in 1..m do
               printf "x="
               let x=int(Console.ReadLine())
               printf "y="
               let y=int(Console.ReadLine())
               yield(x,y)]
let g=([1..n],edges)
printfn "The graph is: %A" g
let adjl=graphToAdjacencyList g  
printfn "The adjacency list is: %A" adjl
let degrees=[for i in 0..n-1 do
                 let node=fst adjl.[i]
                 let degree=(snd adjl.[i]).Length
                 yield(node,degree)]
printfn "Degrees are : %A" degrees
let nodesWithOddDegree=List.filter (fun x -> (snd x)%2<>0) degrees
if nodesWithOddDegree.Length=0 then printfn "The graph has an Eulerian cycle."
else if nodesWithOddDegree.Length=2 then printfn "The graph has an Eulerian path."
else printfn "No Eulerian cycle or path"