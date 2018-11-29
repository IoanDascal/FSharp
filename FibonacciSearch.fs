(*
     https://www.geeksforgeeks.org/fibonacci-search/
     https://en.wikipedia.org/wiki/Fibonacci_search_technique
    Fibonacci Search is a comparison-based technique that uses Fibonacci numbers 
to search an element in a sorted array.Similarities with Binary Search:
  - Works for sorted arrays
  - A Divide and Conquer Algorithm.
  - Has Log n time complexity.
     Differences with Binary Search:
  - Fibonacci Search divides given array in unequal parts
  - Binary Search uses division operator to divide range. Fibonacci Search doesn’t use /,
but uses + and -. The division operator may be costly on some CPUs.
  - Fibonacci Search examines relatively closer elements in subsequent steps. 
So when input array is big that cannot fit in CPU cache or even in RAM, Fibonacci Search can be useful.
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
let fibonacciSearch (arr:int array) key=
    let fib0=ref 0
    let fib1=ref 1
    let fibN= ref 1
    while !fibN<n do
        fib0:=!fib1
        fib1:=!fibN
        fibN:=!fib0 + !fib1
    let offset=ref -1
    let i=ref 0
    while !fibN>1 do
        i:=min (!offset + !fib0) (n-1)
        if arr.[!i]<key then 
            fibN:=!fib1
            fib1:=!fib0
            fib0:= !fibN - !fib1
            offset:= !i 
        else if arr.[!i]>key then
            fibN:=!fib0
            fib1:= !fib1 - !fib0
            fib0:= !fibN - !fib1
        else
            fibN:=0
    printfn "off=%A" !offset
    if !fibN=0 then Some !i
    else if !offset=n-1 then None
    else if !fib1 <> 0 && arr.[!offset+1]=key then Some (!offset+1)
    else None
    
let res=fibonacciSearch a key
if res.IsSome then printfn "Found searched element in position %i" res.Value
    else printfn "The searched element is not in array."
