printf "Dati numarul de linii si cloane n="
let n=int(System.Console.ReadLine())
let matrice=Array2D.create<int> n n 1
printfn "%A" matrice
printfn ""
for i in 1..n-1 do
    for j in 1..n-1 do
        matrice.[i,j] <- matrice.[i,j-1]+matrice.[i-1,j]
for i in 0..n-1 do
    for j in 0..n-1 do
        printf "%i  " matrice.[i,j]
    printfn ""
