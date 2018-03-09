open System
printf "Dati numarul de linii m="
let m=int(System.Console.ReadLine())
printf "Dati numarul de coloane n="
let n=int(System.Console.ReadLine())
let matrice=[for i in 0..m-1 do
                 yield([for j in 0..n-1 do
                           printf "mat[%i,%i]=" i j
                           yield(int(System.Console.ReadLine()))])]
for linie in matrice do
    printfn "%A" linie
let produse=Array.create<int> n 1
printfn "%A" produse
for i in 0..n-1 do
    for j in 0..m-1 do
        produse.[i] <- produse.[i]*matrice.[j].[i]
printfn "%A" produse
let maxi=Array.max produse
printfn "Coloanele care au produsul maxim sunt:"
let res=Array.iteri (fun i x -> if x=maxi then printf "%i " (i+1)) produse
printfn ""
