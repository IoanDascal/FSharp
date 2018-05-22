(*
    Given a graph g write a function that computes the number of connected components
and prints all connected components for graph g and for all partial graphs that can
be obtained from g with at least one edge.
*)

open System.Drawing
type 'a Edge='a*'a
type 'a Graph='a list*'a Edge list
let g=([1;2;3;4;5;6],[(1,2);(2,3);(3,4);(3,5);(4,5);(1,3);(2,6);(2,4);(4,6)])
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
let edges=g |> snd 
let n=edges.Length
let edgesArray=edges |>List.toArray
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
let rec connectedComponentsOfEachPartialGraph k=
    match k<n with
    | false ->()
    | true -> let partialListsOfEdges=nChooseK edgesArray (n-k)
              ///Generate connected componenets for each partial graph
              let rec numberOfConnectedComponents i=
                match i<partialListsOfEdges.Length with
                | false -> ()
                | true -> let g1=(fst g,partialListsOfEdges.[i])  //Contruct partial graph
                          let graph1=g1 |> graphToAdjacencyList
                          let components1=connectedComponents graph1
                          printfn "Connected components for the partial graph with %i edges are : " (n-k)
                          for comp in components1 do
                              printfn "%A" comp
                          printfn "The number of connected components is :%i" components1.Length
                          numberOfConnectedComponents (i+1)
              numberOfConnectedComponents 0
              System.Console.ReadKey() |> ignore
              connectedComponentsOfEachPartialGraph (k+1)

let res=connectedComponentsOfEachPartialGraph 1