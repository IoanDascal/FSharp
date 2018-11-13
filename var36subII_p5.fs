(*
    Given a matrix with n rows and m columns, write a function
that prints the minimum value from each column in reverse order.
*)

open System
printf "Enter the number of rows n="
let n=int(Console.ReadLine())
printf "Enter the number of columns m="
let m=int(Console.ReadLine())
let matrix=[for i in 1..n do
                yield([for j in 1..m do
                           printf "matrix[%i,%i]=" i j
                           yield(int(Console.ReadLine()))])]
printfn "%A" matrix
let printMinimumOnColumn (mat:int list list)=
    for i in m-1.. -1 ..0 do
        let minimum=ref Int32.MaxValue
        for j in 0..n-1 do
            if mat.[j].[i] < !minimum then
                minimum.Value <- mat.[j].[i]
        printf "  %i" minimum.Value
printMinimumOnColumn matrix