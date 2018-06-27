(*
    Given the parents array of a tree witn n vertices, which are
the vertices with exactly two sons.
*)
open System
printf "Enter the number of vertices n="
let n=int(Console.ReadLine())
let parents=[for i in 1..n do yield(printf "parents[%i]=" i
                                    int(Console.ReadLine()))]

printfn "The parents array is : %A" parents
let frequencies=parents |> List.countBy id  
printfn "%A" frequencies
printf "Vertices with 2 sons are :"
for i in 0..frequencies.Length-1 do
    if (snd frequencies.[i])=2 then
        printf "%i  " (fst frequencies.[i])
printfn ""