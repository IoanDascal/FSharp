(*
    https://en.wikipedia.org/wiki/Depth-first_search
    https://www.hackerearth.com/practice/algorithms/graphs/depth-first-search/tutorial/
*)

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
let adg=graphToAdjacencyList g 
printfn "The adjacency list is: %A" adg 
let visited=Array.create<bool> (n+1) false
printf "Enter the start node, start="
let start=int(Console.ReadLine())
let depthFirstSearch (adg:'a AdjacencyList) start=
    let adl=adg |> Map.ofList
    let traversalList=ref []
    let rec DFS node=
        Array.set visited node true
        traversalList:=(node::!traversalList)
        let adjListForNode=Map.find node adl
        for i in 0..adjListForNode.Length-1 do
            if visited.[adjListForNode.[i]]=false then
                DFS adjListForNode.[i]
    DFS start
    let traversal=(!traversalList |> List.rev)
    traversal

let traverse=depthFirstSearch adg start
printfn "%A" traverse
