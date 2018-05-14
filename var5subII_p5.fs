(*
    Generate a matrix with n rows and m columns in wich elements are 
equals to maximum between i and j; where i is the number of the current row
and j is the number of the current column.
*)
open System
printf "Enter n="
let n=int32(Console.ReadLine())
printf "Enter m="
let m=int32(Console.ReadLine())
let matrix=Array2D.init<int> n m (fun row column -> if row>column then row+1 else column+1)
for i in 0..n-1 do
    for j in 0..m-1 do  
        printf "%i " matrix.[i,j]
    printfn ""