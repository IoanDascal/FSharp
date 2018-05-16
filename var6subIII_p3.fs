(*
    Write a function that prints the sum of all n elements of an array of
integer numbers, then the sum of n-1 elements, and so on.
Example : for n=5 and array=[|3;7;9;11;20|] it must print:
   50
   30
   19
   10
   3
*)
open System
printf "Enter number of elements from array n="
let n=int(Console.ReadLine())
let intArray=[|for i in 1..n do
                   printf "Enter vec[%i]=" i
                   yield int(Console.ReadLine())|]

printfn "%A" intArray
let sumOfArray=Array.sum intArray
let lengthOfArray=intArray.Length
let rec print sumOfArray lengthOfArray=
    match lengthOfArray with
    | 1 -> printfn "%i" intArray.[0]
    | _ -> printfn "%i" sumOfArray
           print (sumOfArray-intArray.[lengthOfArray-1]) (lengthOfArray-1)

let pr=print sumOfArray lengthOfArray