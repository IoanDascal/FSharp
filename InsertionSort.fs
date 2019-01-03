(*
    https://en.wikipedia.org/wiki/Insertion_sort
    https://en.wikipedia.org/wiki/Sorting_algorithm#History
*)

open System
printf "Enter the number of elements from array, n="
let n=int(Console.ReadLine())
let vector=[|for i in 0..n-1 do
                 printf "vector[%d]=" i
                 yield(int(Console.ReadLine()))|]

printfn "The unsorted array is:%A" vector

let insertionSort (vector:int array)=
    for i in 0..n-1 do
        let x=vector.[i]
        let mutable j=i-1
        while j>=0 && vector.[j]>x do
            vector.[j+1] <- vector.[j]
            j <- j-1
        vector.[j+1] <- x
    vector

let sortedArray=insertionSort vector
printfn "The sorted array is: %A" sortedArray
    