(*
     The parents array of a tree with n=11 vertices is :
    fathers=(6,5,5,2,0,3,3,3,8,7,7).  How many vertices are leafs.
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
