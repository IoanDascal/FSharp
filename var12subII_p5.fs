(*
    Generate a matrix that contains the last digit of product i*j.
    n - number of rows and columns of the matrix,
    i - the row number
    j - the column number
*)
printf " n="
let n=int(System.Console.ReadLine())
let matrix=[|for i in 0..n-1 do
                  yield ([|for j in 0..n-1 do
                               yield ((i+1)*(j+1)%10)|])|]

for i in 0..n-1 do
    for j in 0..n-1 do
        printf "%3i" matrix.[i].[j]
    printfn ""