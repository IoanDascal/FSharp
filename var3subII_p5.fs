(*
    Construct a square matrix with n rows whose elements from the 
main diagonal are 0, and the rest of elements are equal to n-col,
wher col is the column number.
*)
open System
printf "Enter the number of rows and columns n="
let n=int32(Console.ReadLine())
let matrix=Array2D.init<int> n n (fun row col -> if row=col then 0 else n-col)
printfn "%A" matrix