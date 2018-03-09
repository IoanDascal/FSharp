open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati p="
let p=int(System.Console.ReadLine())
let mutable impar=1
let lista=[for i in 1..n do 
               yield [for j in 1..p do yield (pown impar 2);impar <- impar+2]]

printfn "%A" lista