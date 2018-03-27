(*
    The parents array of a tree with n=7 vertices is :
    father=(5,1,5,1,0,7,5), where vertex 5 is the parent of
    vertex 1, vertex 1 is the parent of vertex 2, etc.
    a. Which vertex is the root of the tree ?
    b. Which vertices are leafs in the tree  ?
*)
open System
printf "Number of vertices n="
let n=int(Console.ReadLine())
let fathers=[for i in 0..n-1 do
              yield(printf "fathers[%i]=" (i+1)
                    int(Console.ReadLine()))]
printfn "%A" fathers
let root=List.findIndex (fun x -> x=0) fathers
printfn "The root of the tree is vertex : %i" (root+1)
let leafs:int option list=[for i in 0..n-1 do
                                 if not (List.contains i fathers) then yield (Some i)]
printfn "Leaf vertex are :"
List.iter (fun x -> if Option.isSome x then printf "%A " <| Option.get x else ()) leafs 
printfn ""