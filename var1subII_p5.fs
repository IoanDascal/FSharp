(*
    Generate a matrix in which one element is equal to  the lowest
    number between the number of the row and the number 
    of the column.
    matrix[i][j]=min(i,j).
*)
open System
printf "Number of rows n="
let n=int32(Console.ReadLine())
printfn "n=%i" n

printf "Number of lines m="
let m=int32(Console.ReadLine())
printfn "m=%i" m

let matrix=
       Array2D.init<int> n m (fun row col -> if row<col then  (row+1)
                                                        else (col+1))
printfn "%A" matrix
