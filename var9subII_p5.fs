(*
    Given a matrix with n rows and n columns. Print in clockwise direction
elements from the first row, then elements from the last column, then elements from 
the last row and elements from the first column.
*)
open System
printf "Enter number of rows and columns n="
let n=int(Console.ReadLine())
let matrix=[|for i in 0..n-1 do
                  yield [|for j in 0..n-1 do
                              yield ( printf "mat[%i,%i]=" i j
                                      int(Console.ReadLine()))|]|]

for i in 0..n-1 do
    for j in 0..n-1 do
        printf "%i  " matrix.[i].[j]
    printfn ""

for i in 0..n-1 do printf "%i " matrix.[0].[i]
for i in 1..n-1 do printf "%i " matrix.[i].[n-1]
for i in n-2.. -1 ..0 do printf "%i " matrix.[n-1].[i]
for i in n-2.. -1 ..1 do printf "%i " matrix.[i].[0]