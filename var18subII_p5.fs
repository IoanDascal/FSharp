open System
printf "Dati n="
let n=int(Console.ReadLine())
let matrice=[for i in 0..n-1 do
                 yield ([for j in 0..n-1 do
                            match i%2 with
                            | 1 -> yield (j+1)
                            | _ -> yield (i+1)])]
for linie in matrice do
    printfn "%A" linie