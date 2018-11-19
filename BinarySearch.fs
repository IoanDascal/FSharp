(*
    https://algs4.cs.princeton.edu/11model/
    https://en.wikipedia.org/wiki/Binary_search_algorithm
    Binary Search: Search a sorted array by repeatedly dividing the search 
interval in half. Begin with an interval covering the whole array. If the 
value of the search key is less than the item in the middle of the interval, 
narrow the interval to the lower half. Otherwise narrow it to the upper half. Repeatedly check until the value is found or the interval is empty.
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
let binarySearch (a:int array) key=
    let rec search left right=
        match left<=right with
        | false -> None
        | true -> let mid=left+(right-left)/2
                  match key=a.[mid] with
                  | true -> Some mid
                  | false -> if key<a.[mid] then search left (mid-1)
                              else search (mid+1) right  
    search 0 (a.Length-1)
let found=binarySearch a key
if found.IsSome then printfn "Found searched element in position=%i" found.Value
    else printfn "The searched element is not in array."