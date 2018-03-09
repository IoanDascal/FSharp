open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati p="
let p=int(System.Console.ReadLine())
let mutable x=0
let matrice=[|for i in 0..n-1 do
                  yield [|for j in 0..p-1 do 
                              yield (pown x 2);x<-x+2|]|]

for i in 0..n-1 do
    for j in 0..p-1 do
        printf "%i " matrice.[i].[j]
    printfn ""
