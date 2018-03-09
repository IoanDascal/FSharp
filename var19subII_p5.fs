open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let matrice=[for i in 1..n do
                 yield ([for j in 1..n do
                            match i%2 with
                            | 1 -> yield (i+j)
                            | _ -> match j with
                                   | 1 -> yield (i-1+j)
                                   | _ -> yield (i+j-2)])]
for linie in matrice do
    printfn "%A" linie