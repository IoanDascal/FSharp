(*
    Given a tree with n nodes, write a program to calculate
the number of leafs from the adjacency matrix reprezentation.
*)

open System
printf "Enter the number of nodes n="
let n=int(Console.ReadLine())

let adjacencyMatrix=Array2D.zeroCreate<int> (n+1) (n+1) 
let m=n-1
printf "Enter the root node r="
let r=int(Console.ReadLine())
for i in 1..m do
    printf "Enter x="
    let x=int(Console.ReadLine())
    printf "Enter y="
    let y=int(Console.ReadLine())
    adjacencyMatrix.[x,y] <- 1
    adjacencyMatrix.[y,x] <- 1

let degrees=[for i in 1..n do
               yield(Array.sum adjacencyMatrix.[i,1..n])]
let leafs=List.countBy (fun x -> x=1) degrees
let nrOfLeafs=if (fst leafs.[0]) then (snd leafs.[0])
                 else (snd leafs.[1])
if degrees.[r-1]=1 then printfn "The number of leafs is : %i" (nrOfLeafs-1)
    else printfn "The number of leafs is : %i" nrOfLeafs
