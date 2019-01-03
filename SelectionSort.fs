(*
    https://www.geeksforgeeks.org/selection-sort/
*)

open System
printf "Enter the number of elements from array, n="
let n=int(Console.ReadLine())
let vector=[|for i in 0..n-1 do
                 printf "vector[%d]=" i
                 yield(int(Console.ReadLine()))|]

printfn "The unsorted array is:%A" vector
let selectionSort (vector:int array)=
    let swap i j=
        let temp=vector.[i]
        vector.[i] <- vector.[j]
        vector.[j] <- temp
    for i in 0..n-2 do
        let mutable min_index=i 
        for j in i+1..n-1 do
            if vector.[j]<vector.[min_index] then
                min_index <- j
        if min_index<>i then 
            swap min_index i
    vector

let sortedArray=selectionSort vector
printfn "The sorted array is: %A" sortedArray