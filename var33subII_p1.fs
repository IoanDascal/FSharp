(*
    Given a graph g, write a function that computes the all paths of a
given length from a specified start node.
     If the start node is 5 then the paths of lenght 2 are: 514, 516, 561. 
*)

open System
open System.Drawing
type 'a Edge='a*'a
type 'a Graph='a list*'a Edge list
let g=([1;2;3;4;5;6],[(1,4);(1,5);(1,6);(2,5);(3,4);(5,6)])
type 'a Node='a*'a list
type 'a AdjacencyList='a Node list
let graphToAdjacencyList ((nodes,edges):'a Graph):'a AdjacencyList=
    let nodesMap=nodes |> List.map (fun n -> n,[]) |> Map.ofList
    (nodesMap,edges)
    ||> List.fold (fun map (a,b) -> map |> Map.add a (b::map.[a]) |> Map.add b (a::map.[b]))
    |> Map.toList
let adg=graphToAdjacencyList g
printfn "%A" adg

let mapFromList=Map.ofList adg
let n=(fst g).Length  
let path=Array.zeroCreate<int> (n+1)
printf "Enter the length of the path :"
let pathLength=int(Console.ReadLine())
printf "Enter the start vertex :"
let start=int(Console.ReadLine())
let completePath p=
    p=pathLength+1
let printPath p=
    for i in 1..p do 
        printf "%i" path.[i]
    printfn ""
let validatePartialPath p=
    match p with  
    | 1 -> path.[1]=start
    | _ -> match Array.contains path.[p] path.[..p-1] with
           | true -> false
           | false -> let verifyAdjacency p=
                          let mutable ok=true
                          for i in 1..p-1 do
                              let list=Map.find path.[i] mapFromList
                              if not (List.exists (fun elem -> elem=path.[i+1]) list) then ok <- false
                          ok
                      verifyAdjacency p  

let rec backtracking p=
    for i in 1..n do  
        path.[p] <- i
        if validatePartialPath p then  
            if completePath p then  
                printPath p
            else
                backtracking (p+1)

let res=backtracking 1

