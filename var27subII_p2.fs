(*
    Given parents array representation of a tree, generate a list
with all leafs from the tree.
*)

open System
printf "Enter the number of vertices from tree n="
let n=int(Console.ReadLine())
let parents=[for i in 1..n do
                 printf "parents[%i]=" i
                 yield(int(Console.ReadLine()))]
printfn "%A" parents
let leafs=[for i in 1..n do
               if not (List.contains i parents) then yield i]
printfn "The leafs in the tree are : %A" leafs