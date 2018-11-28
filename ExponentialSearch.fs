(*
    https://www.geeksforgeeks.org/exponential-search/
        Exponential Search
    The name of this searching algorithm may be misleading as it works in O(Log n) time. 
The name comes from the way it searches an element. Exponential search involves two steps:
   1. Find range where element is present
   2. Do Binary Search in above found range.
       How to find the range where element may be present?
   The idea is to start with subarray size 1, compare its last element with x, then try size 2, 
then 4 and so on until last element of a subarray is not greater. Once we find an index i 
(after repeated doubling of i), we know that the element must be present between i/2 and i 
(Why i/2? because we could not find a greater value in previous iteration)
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
let exponentialSearch (arr:int array) key=
    match arr.[0]=key with
    | true -> Some 0
    | false -> let rec find i=
                   match i<n && arr.[i]<=key with
                   | false -> i 
                   | true -> find (2*i)
               let index=find 1
               let left=index/2
               let right=min index (a.Length-1)
               let rec binarySearch left right=
                   match left<=right with
                   | false -> None
                   | true -> let mid=left+(right-left)/2
                             match key=arr.[mid] with
                             | true -> Some mid
                             | false -> if key<arr.[mid] then binarySearch left (mid-1)
                                        else binarySearch (mid+1) right
               binarySearch left right
let found=exponentialSearch a key
if found.IsSome then printfn "Found searched element in position=%i" found.Value
    else printfn "The searched element is not in array."