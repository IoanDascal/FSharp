(*
    https://www.hackerearth.com/practice/algorithms/searching/ternary-search/tutorial/
    Ternary search, like binary search, is a divide-and-conquer algorithm. It is mandatory 
for the array (in which you will search for an element) to be sorted before you begin the search. 
In this search, after each iteration it neglects 1/3 part of the array and repeats the same 
operations on the remaining 2/3.

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
let ternarySearch (a:int array) key=
    let rec search left right=
        match right>=left with
        | false -> None
        | true -> let mid1=left+(right-left)/3
                  let mid2=right-(right-left)/3
                  match key=a.[mid1] with
                  | true -> Some mid1
                  | false -> match key=a.[mid2] with
                             | true -> Some mid2
                             | false -> if key<a.[mid1] then
                                            search left (mid1-1)
                                        else if key>a.[mid2] then
                                            search (mid2+1) right
                                        else
                                            search (mid1+1) (mid2-1)
    search 0 (a.Length-1)
let found=ternarySearch a key
if found.IsSome then printfn "Found searched element in position=%i" found.Value
    else printfn "The searched element is not in array."