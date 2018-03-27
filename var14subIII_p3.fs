(*
    Given an array of n digits (n<=500), sort them in increasing order.
*)
open System
printf "n="
let n=int(Console.ReadLine())
let frequencies=Array.create<int> 10 0
for i in 0..n-1 do 
    printf "x="
    let x=int(Console.ReadLine())
    frequencies.[x] <- frequencies.[x]+1
printfn "%A" frequencies
for i in 0..9 do
    for j in 0..frequencies.[i]-1 do
        printf "%i " i