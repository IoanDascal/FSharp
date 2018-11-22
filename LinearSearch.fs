(*
    https://www.geeksforgeeks.org/analysis-of-algorithms-set-2-asymptotic-analysis/
*)

open System
printf "Enter n="
let n=int(Console.ReadLine())
let a=[|for i in 1..n do 
            printf "a[%i]=" i
            yield(int(Console.ReadLine()) )|]
printfn "%A" a
printf "Enter element to search, key="
let key=int(Console.ReadLine())
let linearSearch (a:int array) key=
    let rec search index=
        match index>=a.Length with
        | true -> None
        | false -> match a.[index]=key with
                   | true -> Some index
                   | false -> search (index+1)
    search 0
let found=linearSearch a key
if found.IsSome then printfn "Found searched element in position=%i" found.Value
    else printfn "The searched element is not in array."               