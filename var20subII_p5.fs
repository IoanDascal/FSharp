(*
    Generate a matrix with n rows and n columns so that :
- the elements from the first line, last line, first column
and last column are equal to the sum between the number of row 
and the number of column in which they are;
- other elements are equal to the sum of the three neighbor elemnts from
the previous row.
*)
open System
printf "Enter the number of rows and columns  n="
let n=int(Console.ReadLine())
let matrix=Array2D.zeroCreate<int> n n
for i in 0..n-1 do
    for j in 0..n-1 do
        if i=0 || i=n-1 || j=0 || j=n-1 then matrix.[i,j] <- i+j+2
        else matrix.[i,j] <- matrix.[i-1,j-1]+matrix.[i-1,j]+matrix.[i-1,j+1]

for i in 0..n-1 do  
    for j in 0..n-1 do
        printf "%5i" matrix.[i,j]
    printfn ""
