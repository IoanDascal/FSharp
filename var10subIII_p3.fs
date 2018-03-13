(*
    Compute the two biggest distinct prime numbers less or equal than n.
*)
open System
printf " n="
let n=int(Console.ReadLine())
let primes=[]
let rec isPrime number divisor=
    match divisor with
    | 1 -> true
    | _ -> match number%divisor=0 with
           | true -> false
           | false -> isPrime number (divisor-1)
let rec generatePrimesList n (primesList : list<int>)=
    match primesList.Length with
    | 2 -> primesList
    | _ -> if (isPrime n (n/2)) then 
               generatePrimesList (n-1) (n::primesList)
           else
               generatePrimesList (n-1) primesList

let test=generatePrimesList n primes
printfn "%A" (List.rev test )