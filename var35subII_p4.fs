(*
    Given a graph g write a function that computes the number of connected components
and prints all connected components for graph g. How many edges are needded to obtain 
a connected graph. What edges can be added to the initial graph. Test if the new graph is connected.
    Nodes={1,2,3,4,5,6,7,8,9,10}
    Edges={[1,3], [1,5], [2,4], [3,5], [4,8], [7,10]}
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
let adg=graphToAdjacencyList g
printfn "The adjacency list is:%A" adg

let visited=Array.create<bool> (n+1) false
printf "Enter the start node start="
let start=int(Console.ReadLine())
let depthFirstOrder (adg:'a AdjacencyList) start=
    let adl=adg |> Map.ofList
    let traversalList=ref []
    let rec DFS node =
        Array.set visited node true
        traversalList:=(node::!traversalList)
        let adjListForNode=Map.find node adl
        for i in 0..adjListForNode.Length-1 do
            if visited.[adjListForNode.[i]]=false then
                DFS adjListForNode.[i] 
    DFS start
    let traversal=(!traversalList |> List.rev)
    traversal
let traverse=depthFirstOrder adg start
printfn "%A" traverse
let connectedComponents (g:'a AdjacencyList)=
    Array.fill visited 0 (n+1) false
    let nodes=g |> List.map fst |> Set.ofList
    let start=g |> List.head |> fst
    let rec loop acc g start nodes=
        let dfst=depthFirstOrder g start |> Set.ofList
        let nodes'=Set.difference nodes dfst
        if Set.isEmpty nodes' then
            g::acc
        else
            ///once we have the dfst set we can remove those nodes from the
            ///graph and add them to the solution and continue with the remaining nodes
            let (cg,g')=g |> List.fold (fun (xs,ys) v -> if Set.contains (fst v) dfst then (v::xs,ys) else (xs,v::ys)) ([],[])
            let start'=List.head g' |> fst
            loop (cg::acc) g' start' nodes'
    loop [] g start nodes

let components=connectedComponents adg
printfn "Connected components for the initial graph are: "
for compon in components do  
    printfn "%A" compon
printfn "The number of connected components for the initial graph is :%i" components.Length
printfn "We must add %i edges to the initial graph to obtain a connected graph." (components.Length-1)
let addEdgesToGraph (g:'a Graph)=
    let newEdges=[for i in 1..components.Length-1 do
                      yield (fst components.[i-1].[0],fst components.[i].[0])]
    printfn "The new edges that can be added are: %A" newEdges
    ([1..n],edges@newEdges)
let newGraph=addEdgesToGraph g
printfn "The new graph is: %A" newGraph
// Verify if the new graph is a connected graph.
let newComponents=connectedComponents (newGraph |> graphToAdjacencyList)
if newComponents.Length=1 then printfn "The new graph is a connected graph." 
    else 
        printfn "The new graph is not a connected graph"