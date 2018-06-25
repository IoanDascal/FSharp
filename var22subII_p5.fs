(*
    Generate a matrix with m rows and n columns that contains
all numbers from 1 to m*n in decreasing order.
Example: For m=4 n=3
The matrix is: 12 11 10
                9  8  7
                6  5  4
                3  2  1
*)
open System
printf "Enter the number of rows m="
let m=int(Console.ReadLine())
printf "Enter the number of columns n="
let n=int(Console.ReadLine())
let matrix=Array2D.zeroCreate<int> m n
for i in 0..m-1 do
    for j in 0..n-1 do
        matrix.[i,j] <- m*n-(i*n+j)
for i in 0..m-1 do
    for j in 0..n-1 do 
        printf "%4i " matrix.[i,j]
    printfn ""