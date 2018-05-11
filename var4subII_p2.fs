(*
     The parents array of a tree with n=8 vertices is :
fathers=(6,5,5,2,0,3,3,3).  How many vertices are leafs.
*)
open System
printf "Enter n="
let n=int32(Console.ReadLine())
let fathers=[for i in 1..n do
              yield(printf "fathers[%i]=" i
                    int(Console.ReadLine()))]
printfn "The fathers array is : %A" fathers
let leafs=List.filter (fun x -> not (List.contains x fathers)) [1..n]
printfn "The leafs are : %A" leafs
printfn "The tree has  %i leafs" leafs.Length
printfn "The root of the tree is %i" ((List.findIndex (fun elem -> elem=0) fathers)+1) 