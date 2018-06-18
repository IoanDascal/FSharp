(*
    Generate a matrix with n rows and n columns so that :
 - Each element from an odd line is the sum between the number 
of the current row and the number of the current column;
 - Each element from an even line is equal to the minimum value
between the element from the previous row and the same column and an
element from the previous row and a neighbor column.
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
let matrix=[for i in 1..n do
                 yield ([for j in 1..n do
                            match i%2 with
                            | 1 -> yield (i+j)
                            | _ -> match j with
                                   | 1 -> yield (i-1+j)
                                   | _ -> yield (i+j-2)])]
for line in matrix do
    printfn "%A" line