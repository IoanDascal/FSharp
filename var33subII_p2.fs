(*
    Given the parents array representation of a tree, write a program 
to make a list of all descendants of a node x.
    parents=(8;8;0;3;4;3;4;7;1;2;3;3;7;8;3;5;6;8)
*)

open System
printf "Enter the number of vertices n="
let n=int(Console.ReadLine())
let parents=[for i in 1.. n do 
              yield(printf "parents[%i]=" i
                    int(Console.ReadLine()))]
printf "Enter x="
let x=int(Console.ReadLine())

let rec getDescendants parentsList descendantsList=
    match parentsList with
    | [] -> descendantsList
    | hd::tail -> let descendantsListForHd=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=hd then (i+1) else 0)  parents)
                  getDescendants tail (descendantsList@descendantsListForHd)
let getAllDescendantsOfX initialVertex allDescendants=
    let descendants=getDescendants [initialVertex] []
    let rec getAllDescendants descendants allDescendants=
        match descendants with
        | [] -> allDescendants
        | dList -> let newDescendants=getDescendants dList []
                   getAllDescendants newDescendants (newDescendants@allDescendants)
    let allDescendantsForVertexX=getAllDescendants descendants descendants
    allDescendantsForVertexX
let allDescendantsList=getAllDescendantsOfX x []
printfn "--->All descendants of node %d are: %A" x allDescendantsList
let findLeafs (parents:int list)=
    let rec loop node leafsList=
        match node<=parents.Length with
        | false -> leafsList
        | true -> match (List.tryFind (fun x -> x=node) parents) with
                  | None -> loop (node+1) (node::leafsList)
                  | Some(node) -> loop (node+1) leafsList    
    loop 1 []

let res=findLeafs parents
printfn "Leafs of the tree are :%A" res

