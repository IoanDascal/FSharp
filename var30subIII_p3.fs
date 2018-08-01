(*
      Given an array which contains n integer numbers, write
a function to calculate the sum of the elements between indices
0.. i-2 and betwwen indices j..n-1.
( 0 <= i <= j < n )
*)

open System
printf "Enter the number of elements from array n="
let n=int(Console.ReadLine())
printf "Enter i="
let i=int(Console.ReadLine())
printf "Enter j="
let j=int(Console.ReadLine())
let numbers=[for i in 1..n do
                yield(printf "numbers[%i]=" i 
                      int(Console.ReadLine()))]
let partialSum=List.sum numbers - List.sum numbers.[i-1..j-1]
printfn "%i" partialSum