(*
    Given an integer number n<=20, create a matrix with n rows and
n columns wich contains first n*n even numbers not divisible by 3.
*)

let matrix=Array2D.zeroCreate<int> 20 20
let mutable nrNotDivWith3=2
printf "Enter the number of rows and columns n="
let n=int(System.Console.ReadLine())
for i in 0..n-1 do
    for j in 0..n-1 do
        if nrNotDivWith3%3=0 then
            nrNotDivWith3 <- nrNotDivWith3+2
            matrix.[i,j] <- nrNotDivWith3
        else 
            matrix.[i,j] <- nrNotDivWith3
        nrNotDivWith3 <- nrNotDivWith3+2
for i in 0.. n-1 do
    for j in 0..n-1 do
        printf "%i  " matrix.[i,j]
    printfn ""