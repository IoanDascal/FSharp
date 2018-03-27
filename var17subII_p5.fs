(*
    Generate a matrix with n rows and n columns so that :
    - every item from the antidiagonal must be equal to n,
    - every item above the antidiagonal must be lower with 1 than the right neighbor
    - every item below the antidiagonal must be greater with 1 than the left neighbor
*)
open System
printf " n="
let n=int(Console.ReadLine())
let matrice=[for i in 0..n-1 do
                 yield ([for j in (i+1)..(n+i) do
                             yield j])]

for linie in matrice do 
    printfn "%A" linie