(*
    Write a fuction to generate a matrix with n rows and
n columns with elements equals to n-row. The elements from
the antidiagonal must have their value equal to 0.
*)
open System
printf "Enter number of rows and columns n="
let n=int32(Console.ReadLine())
let matrix=Array2D.init<int> n n (fun row col -> if row+col=n-1 then 0 else n-row)
for i in 0..n-1 do
    for j in 0..n-1 do
        printf "%i " matrix.[i,j]
    printfn ""