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
let bubbleSort (vector:int [])=
    let swap i j=
        let temp=vector.[i]
        vector.[i] <- vector.[j]
        vector.[j] <- temp
    let mutable sorted=false
    let mutable i=vector.Length-1
    while not sorted do
        sorted <- true
        for j=1 to i do
            if vector.[j-1]>vector.[j] then
                swap (j-1) j
                sorted <- false
        i <- i-1
    vector
    
let sortedArray=bubbleSort vector
printfn "The sorted array is: %A" sortedArray

//For Lists Version 1
let BubbleSort1 (lst : int list) = 
    let rec sort accum rev lst =
        match lst with
        | [] -> match rev with
                | true -> accum |> List.rev
                | false -> accum |> List.rev |> sort [] true
        | x::y::tail when x > y -> sort ([y]@accum) false ([x]@tail)
        | head::tail -> sort ([head]@accum) rev tail
    sort [] true lst

let res=BubbleSort1 [45;34;2;43;12]
printfn "%A" res

//For Lists Version 2
let BubbleSort2 (lst : int list) = 
    let rec sort accum sorted lst =
         match lst with
         | [] -> match sorted with
                 | true -> accum
                 | false -> sort [] true accum
         | x::y::tail when x > y -> sort (accum@[y]) false ([x]@tail)
         | head::tail -> sort (accum@[head]) sorted tail
    sort [] false lst

printfn "%A" ([4;12;75;23;89;1;-12;34] |> BubbleSort2)