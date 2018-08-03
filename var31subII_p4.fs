(*
    Generate a matrix using the next C++ program sequence:
    for(j=1;j<=n;j++)
        for(i=1;i<=m;i++)
            a[i][j]=2*i+j;
    Print the elements from the matrix and then print only the elements 
from the third column.
*)

open System
printf "Enter the number of rows m="
let m=int(Console.ReadLine())
printf "Enter the number of columns n="
let n=int(Console.ReadLine())
let matrix=Array2D.create<int> (m+1) (n+1) 1
for j in 1..n do
    for i in 1..m do
        matrix.[i,j] <- 2*i+j
printfn "The matrix is:\n"
for i in 1..m do
    for j in 1..n do
        printf "%4i" matrix.[i,j]
    printfn ""
printf "Enter the number of column to print c="
let c=int(Console.ReadLine())
printf "The elements from column %i are : " c  
for i in 1..m do printf "%4i" matrix.[i,c]
printfn ""