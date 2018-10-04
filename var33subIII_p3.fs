(*
    Write a function sum3::int list -> int to calculate the sum of 
all numbers that are divisible by 3 from a list of integer numbers.
*)

open System
printf "Enter the number of elements from the list n="
let n=int(Console.ReadLine())
let listOfInt=[for i in 1..n do yield (printf "list[%d]=" i
                                       let x=int(Console.ReadLine())
                                       x)]
printfn "The list is: %A" listOfInt
let sum3 list=
    let s=List.sumBy (fun x -> if x%3=0 then x else 0) list
    s

printfn "The sum of elements divisible by 3 is: %d" (sum3 listOfInt)