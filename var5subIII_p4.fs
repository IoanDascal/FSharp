(*
    - Write a function f:int -> int that return the lowest prime
divisor of an integer number a;
    - Using function f write another function that reads n integer
numbers and prints in increasing order only the prime numbers, 
if there exists.
*)
open System
printf "Enter n="
let n=int32(Console.ReadLine())
let rec lowestPrimeDivisor nr div=
   match nr%div with
   | 0 -> div
   | _ -> lowestPrimeDivisor nr (div+1)

let test1=lowestPrimeDivisor n 2
printfn "The divisor is =%i" test1
let primes=[|for i in 1..n do 
               printf "sir[%i]=" i
               yield int32(Console.ReadLine())|] 
           |> Array.filter (fun x -> x=(lowestPrimeDivisor x 2))
           |> Array.sort

if primes.Length=0 then printfn "There are no prime numbers"
    else
        printfn "%A" primes