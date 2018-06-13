(*
    Given a matrix with m rows and n columns, write a funtion
to find the minimum value on each row and another function to find
the maximum of these values.
*)

open System
printf "Enter the number of rows m="
let m=int32(Console.ReadLine())
printf "Enter the number of columns n="
let n=int32(Console.ReadLine())
let matrix=[|for i in 1..m do
                 yield[|for j in 1..n do
                           printf "mat[%i,%i]=" i j
                           yield(int32(Console.ReadLine()))|]|]
for row in matrix do  
    printfn "%A" row
let minimumOnRows=[|for i in 0..m-1 do
                        yield(Array.min matrix.[i])|]
printfn "The minimum values on each row are : %A" minimumOnRows
let maximumValue=Array.max minimumOnRows
printfn "The maximum value is %i" maximumValue