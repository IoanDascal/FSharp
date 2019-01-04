(*
    https://www.geeksforgeeks.org/bubble-sort/
    https://rosettacode.org/wiki/Sorting_algorithms/Bubble_sort#F.23
*)

open System
printf "Enter the number of elements from array, n="
let n=int(Console.ReadLine())
let vector=[|for i in 0..n-1 do
                 printf "vector[%d]=" i
                 yield(int(Console.ReadLine()))|]

printfn "The unsorted array is:%A" vector
let bubbleSort (vector:int array)=
    let swap i j=
        let temp=vector.[i]
        vector.[i] <- vector.[j]
        vector.[j] <- temp
    let mutable sorted=false
    let mutable i=vector.Length-1
    while sorted=false do
        sorted <- true
        for j=1 to i do
            if vector.[j-1]>vector.[j] then
                swap (j-1) j
                sorted <- false
        i <- i-1
    vector
    
let sortedArray=bubbleSort vector
printfn "The sorted array is: %A" sortedArray

//For lists
let BubbleSort (lst : list<int>) = 
    let rec sort accum rev lst =
        match lst, rev with
        | [], true -> accum |> List.rev
        | [], false -> accum |> List.rev |> sort [] true
        | x::y::tail, _ when x > y -> sort (y::accum) false (x::tail)
        | head::tail, _ -> sort (head::accum) rev tail
    sort [] true lst

let res=BubbleSort [45;34;2;43;12]
printfn "%A" res