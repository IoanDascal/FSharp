(*
    A matrix with m rows and n columns, contains numbers from set 
{0,1,2}. Write a programme to print the columns with the maximum
product.
Example: For 2 1 1 0
             1 1 1 1
             2 2 2 1
             1 2 1 1
it should print : 1 2
*)

open System
printf "Enter thge number of rows m="
let m=int(Console.ReadLine())
printf "Enter the number of columns n="
let n=int(Console.ReadLine())
let matrix=[|for i in 1..m do
                yield[|for j in 1..n do
                          printf "mat[%i,%i]=" i j
                          yield(int(Console.ReadLine()))|]|]
printfn "%A" matrix
let products=Array.create m 1
for i in 0..n-1 do  
    for j in 0..m-1 do
        products.[i] <- products.[i]*matrix.[j].[i]
let maximum=Array.max products
products |> Array.iteri (fun i x -> if x=maximum then printf "%i " (i+1))