(*
    Given a graph g write a function that computes the number of connected components
and prints all connected components.
*)

open System.Drawing
type 'a Edge='a*'a
type 'a Graph='a list*'a Edge list
let g=([1..60],[(1,60);(2,30);(3,5);(4,30);(20,60)])
type 'a Node='a*'a list
type 'a AdjacencyList='a Node list
let graphToAdjacencyList ((nodes,edges):'a Graph):'a AdjacencyList=
    let nodesMap=nodes |> List.map (fun n -> n,[]) |> Map.ofList
    (nodesMap,edges)
    ||> List.fold (fun map (a,b) -> map |> Map.add a (b::map.[a]) |> Map.add b (a::map.[b]))
    |> Map.toList
let adg=graphToAdjacencyList g
printfn "%A" adg
let depthFirstOrder (g:'a AdjacencyList) start=
    let nodes=g |> Map.ofList
    let color=g |> List.map(fun (v,_) -> v,Color.White) |> Map.ofList |> ref
    let pi=ref [start]
    let rec dfs u=
        color:=Map.add u Color.Gray !color
        for v in nodes.[u] do
            if(!color).[v]=Color.White then
                pi:=(v::!pi)
                dfs v
        color:=Map.add u Color.Black !color
    dfs start
    !pi |> List.rev
let traverse=depthFirstOrder (g |> graphToAdjacencyList) 1
let traverse1=depthFirstOrder (g |> graphToAdjacencyList) 3
let traverse2=depthFirstOrder (g |> graphToAdjacencyList) 6
let connectedComponents (g:'a AdjacencyList)=
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
let graph=g |> graphToAdjacencyList
let componnents=connectedComponents graph
printfn "Connected components are for the initial graph : "
for compon in componnents do  
    printfn "%A" compon
printfn "The number of connected components for the initial graph is :%i" componnents.Length