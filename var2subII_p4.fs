(*
    Given a matrix with n rows and n columns,
write a function that returns the last digit of the 
sum of elements from a row r.
*)

open System
printf "Enter the number of rows and columns n="
let n=int32(Console.ReadLine())
let matrix=[|for i in 0..n-1 do
                 yield[|for j in 0..n-1 do 
                            printf "mat[%i][%i]=" i j
                            let x=int32(Console.ReadLine())
                            yield x|]|]
for row in matrix do
    printfn "%A" row
printf "Enter the row r="
let r=int32(Console.ReadLine())
let sum=matrix.[r-1] |> Array.sum
printfn "The last digit =%i" (sum%10)