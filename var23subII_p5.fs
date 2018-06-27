(*
    Generate a matrix with m rows and n columns so that the 
first row must contain numbers 1,2,...,n, and the first column 
must contain numbers 1,2,...,m. All ather elements are given by 
the relation matrix[i,j]=matrix[i-1,j]+matrix[i,j-1]. Print the 
last digit of the number from the last row and last column.
*)
open System
printf "Enter the number of rows m="
let m=int(Console.ReadLine())
printf "Enter the number of columns n="
let n=int(Console.ReadLine())
let matrix=Array2D.zeroCreate<int> m n
for i in 0..m-1 do
    for j in 0..n-1 do
        match i with
        | 0 -> matrix.[i,j] <- j+1
        | _ -> match j with
               | 0 -> matrix.[i,j] <- i+1
               | _ -> matrix.[i,j] <- matrix.[i-1,j]+matrix.[i,j-1]
printfn "%A" matrix
printfn "The last digit is : %i" (matrix.[m-1,n-1]%10)