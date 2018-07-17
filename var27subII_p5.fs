(*
    Generate a matrix so that all elements from the first row,
first column and last column are equal to 1. Other elements are 
calculated with A[i,j] <- A[i-1,j-1]+A[i-1,j]+A[i-1,j+1]
*)

printf "Enter the number of rows and columns n="
let n=int(System.Console.ReadLine())
let matrix=Array2D.create<int> n n 1
for i in 1..n-1 do
    for j in 1..n-2 do
        matrix.[i,j] <- matrix.[i-1,j-1]+matrix.[i-1,j]+matrix.[i-1,j+1]
for i in 0..n-1 do
    for j in 0..n-1 do  
        printf "%5i" matrix.[i,j]
    printfn ""