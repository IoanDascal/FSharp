(*
    https://infoarena.ro/job_detail/223158?action=view-source
    https://www.techiedelight.com/breadth-first-search/
    https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/
*)

open System.Drawing
open System
open System.Collections.Generic
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
let m= int(Console.ReadLine())
let edges=[for i in 1..m do
               printf "x="
               let x=int(Console.ReadLine())
               printf "y="
               let y=int(Console.ReadLine())
               yield (x,y)]
let g=([1..n],edges)
printfn "The graph is:%A" g 
let adjg=graphToAdjacencyList g 
printfn "The adjacency list is: %A" adjg
let visited=Array.create<bool> (n+1) false
printf "Enter the start node, start="
let start=int(Console.ReadLine())
let breadthFirstSearch (adjg:'a AdjacencyList) start=
    let adl=adjg |> Map.ofList
    let traversalList=ref []
    let queue=new Queue<'a>()
    queue.Enqueue start
    while queue.Count>0 do
        let v=queue.Dequeue()
        Array.set visited v true
        traversalList:=(v::!traversalList)
        let adjListForNode=Map.find v adl
        for i in 0..adjListForNode.Length-1 do
            if visited.[adjListForNode.[i]]=false then
                Array.set visited adjListForNode.[i] true
                queue.Enqueue adjListForNode.[i]
    let traversal=(!traversalList |> List.rev)
    traversal
let traverse=breadthFirstSearch adjg start
printfn "%A" traverse