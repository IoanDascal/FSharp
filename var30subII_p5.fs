(*
    Write a program to generate a matrix so that the elements 
from the first row and and from the first column are equal to 1
and for other elements use the relation : A[i,j]=A[i,j-1]+A[i-1,j].
*)
printf "Enter the number of rows and columns n="
let n=int(System.Console.ReadLine())
let matrix=Array2D.create<int> n n 1
for i in 1..n-1 do
    for j in 1..n-1 do
        matrix.[i,j] <- matrix.[i,j-1]+matrix.[i-1,j]
for i in 0..n-1 do
    for j in 0..n-1 do
        printf "%4i  " matrix.[i,j]
    printfn ""
