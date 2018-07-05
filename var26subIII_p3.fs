(*
    Write a function to generate the lowest k multiples of n.
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
printf "Enter k="
let k=int(Console.ReadLine())
let list=[for i in k.. -1 ..1 do yield(n*i)]
printfn "%A" list
printfn ""
