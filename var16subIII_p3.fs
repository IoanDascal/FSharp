(*
    Given a list of n integers less than 1000 and a digit k,
    select all numbers with the last digit equal to k and are
    divisible with k.
*)
open System
printf "n="
let n=Console.ReadLine() |> int
printf "k="
let k=Console.ReadLine() |> int
printfn "The elements of the list are :"
let numbers=[for i in 0..n-1 do
                yield (printf "numbers[%i]=" i
                       int(System.Console.ReadLine())) ] 

printfn "%A" numbers
let validateNumber nr k=
    match nr%k with
    | 0 -> nr%10=k
    | _ -> false

let res = List.choose (fun x -> if (validateNumber x k) then Some x else None) numbers
printfn "Numbers are : %A" res