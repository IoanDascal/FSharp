(*
    The parents array of a tree with n=9 vertices is :
    father=(8,7,6,6,7,7,8,0,8), where vertex 8 is the parent of
    vertex 1, vertex 7 is the parent of vertex 2, etc.
    a. Which vertex is the root of the tree?
    b. Which vertices are the childrens if vertex 7
*)
open System
printf "Number of vertices n="
let n=int(Console.ReadLine())
let fathers=[for i in 1..n do
              yield (printf "fathers[%i]=" i
                     int(Console.ReadLine()))]
printfn "%A" fathers
let root= fathers |> List.findIndex (fun x -> x=0)
printfn "The root of the tree is vertex = %i" (root+1)
printfn "Childrens of vertex 7 are :"
let childrens=[for i in 0..n-1 do
                     if fathers.[i]=7 then yield (i+1)]
printfn "%A" childrens
