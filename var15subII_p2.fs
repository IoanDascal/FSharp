(*
     The parents array of a tree with n=7 vertices is :
    fathers=(5,1,5,1,0,7,5).  How many vertices are brothers  with vertex 1.
*)
open System
printf " n="
let n=int(Console.ReadLine())
let fathers=[for i in 1..n do
              yield(printf "fathers[%i]=" i
                    int(Console.ReadLine()))]
printfn "%A" fathers
let fatherOfVertex1=fathers.[0]
let nrOfBrothers vertex=List.fold (fun acc x -> match x=vertex with
                                                | true -> (acc+1) 
                                                | false -> acc ) 0 fathers

let brothers=(nrOfBrothers fatherOfVertex1)-1
printfn "%i" brothers
