open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let matrice=Array2D.zeroCreate<int> n n
for i in 0..n-1 do
    for j in 0..n-1 do
        if i=0 || i=n-1 || j=0 || j=n-1 then matrice.[i,j] <- i+j+2
        else matrice.[i,j] <- matrice.[i-1,j-1]+matrice.[i-1,j]+matrice.[i-1,j+1]

printfn "%A" matrice
