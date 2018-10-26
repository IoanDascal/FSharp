(*

*)

open System.Drawing
open System
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
               yield (x,y)]
let g=([1..n],edges)
printfn "The graph is:%A" g
let adg=graphToAdjacencyList g |> Map.ofList
printfn "The adjacency list is:%A" adg
let adjListForV v=adg.[v]
let visited=Array.create<bool> (n+1) false
printf "Enter the start node start="
let start=int(Console.ReadLine())
let traversalList=ref []
let rec DFS node =
    Array.set visited node true
    traversalList:=(node::!traversalList)
    let adjListForNode=adjListForV node
    for i in 0..adjListForNode.Length-1 do
        if visited.[adjListForNode.[i]]=false then
            DFS adjListForNode.[i] 
DFS start
let traversal=(!traversalList |> List.rev)
printfn "%A" traversal
let edgesFromTraversalList=[for i in 1..n-1 do
                                if traversal.[i]>traversal.[i-1] then
                                    yield (traversal.[i-1],traversal.[i])
                                else
                                    yield (traversal.[i],traversal.[i-1])]
printfn "%A" edgesFromTraversalList
let set1=edges |> Set.ofList
let set2=edgesFromTraversalList |> Set.ofList
let edgesToRemove=Set.difference set1 set2
printfn "The edges that can be eliminated from the graph to obtain a tree are: %A" edgesToRemove