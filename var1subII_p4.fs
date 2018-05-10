(*
     The parents array of a tree with n=8 vertices is :
    fathers=(6,6,5,0,6,4,4,7).  How many vertices are leafs.
    Calculate the height of the tree.
*)
open System
printf " n="
let n=int(Console.ReadLine())
let fathers=[for i in 1..n do
              yield(printf "fathers[%i]=" i
                    int(Console.ReadLine()))]
printfn "%A" fathers
let root=fathers |> List.tryFindIndex (fun x -> x=0)
if root.IsSome then printfn "The root of the tree is vertex :%d " (root.Value+1)
    else printfn "I can't find the root of the tree"
let isLeaf lst (y:int)=
    let leaf=lst |> List.tryFind (fun x -> x=y)
    leaf.IsNone
let leafs=[for i in 1..n do 
              if (isLeaf fathers i) then yield i]

printfn "The leafs of the tree are: %A" leafs

let childs x=[for i in 1..n do if x=fathers.[i-1] then yield i]   
let childsOnNextLevel xs=
    let rec level xs ys=
        match xs with
        | x::xss -> let lst=childs x
                    level xss (List.append lst ys)
        | [] -> ys
    level xs []
let rec treeHeight nodes height=
    match nodes with
    | [] -> height-1
    | xs -> printfn "Next nodes %A  are on level %i" nodes height
            treeHeight (childsOnNextLevel xs) (height+1)

let res=treeHeight [root.Value+1] 0
printfn "The height of the tree is %i" res
