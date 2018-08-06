(*
    Given a directed graph print all nodes with outdegree equal to 2.
*)

open System.Drawing
type 'a Edge='a*'a
type 'a Graph='a list*'a Edge list
let g=([1;2;3;4;5;6],[(1,5);(1,6);(2,1);(2,4);(2,5);(3,1);(3,5);(4,1);(4,2);(5,2);(6,2);(6,4);(6,5)])
type 'a Node='a*'a list
type 'a AdjacencyList='a Node list
let graphToAdjacencyList ((nodes,edges):'a Graph):'a AdjacencyList=
    let nodesMap=nodes |> List.map (fun n -> n,[]) |> Map.ofList
    (nodesMap,edges)
    ||> List.fold (fun map (a,b) -> map |> Map.add a (b::map.[a]))
    |> Map.toList
let adg=graphToAdjacencyList g
printfn "The adjacency list is :"
adg |> List.iter (fun (v,lst) -> printf "%i --> " v
                                 printfn "%A" lst)

let findOutdegrees (g:'a AdjacencyList)=g |> List.map (fun (v,lst) -> (v,(List.length lst)))
let outdegrees=findOutdegrees adg
printfn "%A" outdegrees
printf "The nodes with outdegree equal to 2 are :"
outdegrees |> List.iter (fun (v,deg) -> if deg=2 then printf "%i " v)