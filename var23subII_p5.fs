open System
printf "Dati numarul de linii m="
let m=int(System.Console.ReadLine())
printf "Dati numarul de coloane n="
let n=int(System.Console.ReadLine())
let matrice=Array2D.zeroCreate<int> m n
for i in 0..m-1 do
    for j in 0..n-1 do
        match i with
        | 0 -> matrice.[i,j] <- j+1
        | _ -> match j with
               | 0 -> matrice.[i,j] <- i+1
               | _ -> matrice.[i,j] <- matrice.[i-1,j]+matrice.[i,j-1]
printfn "%A" matrice
printfn "Ultima cifra este : %i" (matrice.[m-1,n-1]%10)