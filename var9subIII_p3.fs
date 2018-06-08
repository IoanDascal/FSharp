(*
    Write a funtion sub : int-> int-> unit that
prints in decreasing order the first n natural numbers
divisible with k. 
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
printf "Enter k="
let k=int(Console.ReadLine())
let rec sub n k=
    match n with
    | 0 -> printfn ""
    | _ -> printf "%i " (n*k)
           sub (n-1) k
let res= sub n k