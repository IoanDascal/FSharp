(*
    Generate a matrix with n rows and n columns.
    The elements from the leading diagonal and from antidiagonal
    must be equal to 0.
    The elements that are above the two diagonals must equal to 1;
    the elements that are below the two diagonals must equal to 2,
    and other elements must be equal to 3.
*)
open System
printf "n="
let n=Console.ReadLine() |> int
let matrix=[|for i in 0..n-1 do
                  yield ([|for j in 0..n-1 do
                               if i=j || n-i-1=j then yield 0
                                   else if j>i && j<n-i-1 then yield 1
                                            else if j<i && j>n-i-1 then yield 2
                                                     else yield 3|])|]

for linie in matrix do
    printfn "%A" linie