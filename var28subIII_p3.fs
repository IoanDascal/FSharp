(*
    Given an array of n real numbers write a program to calculate
how many numbers are equals to the average between other n-1 numbers.
*)

open System
printf "Dati n="
let n=int(Console.ReadLine())
let vector=[|for i in 1..n do
                 yield(printf "v[%i]=" i
                       float(Console.ReadLine()))|] 
let sum=Array.sum vector
let averages=[|for i in 0..n-1 do yield((sum-vector.[i])/float(n-1))|]

let res=Array.map2 ( fun x y -> if x=y then x else 0.0) vector averages
let equals=Array.countBy (fun x -> if x<>0.0 then x else 0.0) res
if (fst equals.[0])<>0.0 then printfn "Sunt egale : %i medii"  (snd equals.[0])
    else printfn "Sunt egale : %i medii" (snd equals.[1])
