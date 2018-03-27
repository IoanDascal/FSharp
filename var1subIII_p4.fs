(*
     Given an array of numbers v :
     a. Write a function to calculate the numbers of items that are lower than a value x. 
     b. Using the function above print "YES" if items from v are distinct, or print "NO"
     if items are not distinct.
*)
open System
printf "Enter the number of elements from array n="
let n=int32(Console.ReadLine())
let v=[| for i in 1..n do 
            printf "v[%i]=" i 
            yield int32(Console.ReadLine())|]
printfn "%A" v
let mutable a=0
//    a.
let countLower acc el=
    match el<a with
    | true -> acc+1
    | false -> acc
//   b.
let frequencies=Array.create v.Length 0
for i in 0..frequencies.Length-1 do
    a <- v.[i]
    let res=Array.fold countLower 0 v
    Array.set frequencies i res
printfn "%A" frequencies

let sum=((frequencies.Length-1)*(frequencies.Length))/2
printfn "sum=%d" sum
let mesaj=if  Array.sum frequencies = sum then "YES" else "NO"
printfn "%s" mesaj