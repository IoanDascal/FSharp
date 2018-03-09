open System
printf "Dati m="
let m=int(System.Console.ReadLine())
printf "Dati n="
let n=int(System.Console.ReadLine())
let matrice=Array2D.zeroCreate<int> m n
for i in 0..m-1 do
    for j in 0..n-1 do
        matrice.[i,j] <- m*n-(i*n+j)
for i in 0..m-1 do
    for j in 0..n-1 do 
        printf "%A " matrice.[i,j]
    printfn ""