(*
    Given a matrix with n rows and n columns, write a function
that prints the minimum value from each column.
*)

open System
printf "Enter n="
let n=int(Console.ReadLine())
let matrix=[for i in 1..n do
                yield([for j in 1..n do
                          printf "matrix[%i,%i]=" i j
                          yield(int(Console.ReadLine()))])]
for line in matrix do
    printfn "%A" line
let printMinimumOnColumn (mat:int list list)=
    for i in 0..n-1 do
        let minimum=ref Int32.MaxValue
        for j in 0..n-1 do
            if mat.[j].[i]< !minimum then
                minimum.Value <- mat.[j].[i]
        printf "  %i " minimum.Value
printMinimumOnColumn matrix