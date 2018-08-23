(*
    Generate a matrix using next C++ snippet:
    for(j=1;j<=n;j++)
        for(i=m;i>=1;i--)
            a[i][j]=i+j
    
    Print the elements from a given row r.
*)

open System
printf "Enter the numbers of rows n="
let n=int(Console.ReadLine())
printf "Enter the numbers of columns m="
let m=int(Console.ReadLine())
let matrix=Array2D.zeroCreate (n+1) (m+1)
for i in 1..n do
    for j in m.. -1 ..1 do  
        matrix.[i,j] <- i+j

for i in 1..n do
    for j in 1..m do
        printf "%i " matrix.[i,j]
    printfn ""

printf "Enter a row to print r="
let r=int(Console.ReadLine())
for i in 1..m do
    printf "%i " matrix.[r,i]
printfn ""