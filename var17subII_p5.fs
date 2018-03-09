open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let matrice=[for i in 0..n-1 do
                 yield ([for j in (i+1)..(n+i) do
                             yield j])]

for linie in matrice do 
    printfn "%A" linie