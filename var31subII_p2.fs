(*
    Given the parents array representation of a tree, write a program 
to make a list of all ancestors of a node x.
*)
open System
printf "Enter the number of vertices n="
let n=int(Console.ReadLine())
let parents=[for i in 1.. n do 
              yield(printf "parents[%i]=" i
                    int(Console.ReadLine()))]
printf "Enter x="
let x=int(Console.ReadLine())
let getAllAncestors (node:int)=
    let rec getAncestors (ancestors:int list) node=
        printfn "ancestors=%A" ancestors
        printfn "Press any key : "
        Console.ReadKey() |> ignore
        match parents.[node-1] with
        | 0 -> ancestors
        | _ -> getAncestors (parents.[node-1]::ancestors) (parents.[node-1])
    let ancestors=getAncestors [] node
    ancestors
let ancestors=getAllAncestors x
printfn "The ancestors of node %i are : %A" x ancestors 
          