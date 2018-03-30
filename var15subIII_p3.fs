(*
    Given a natural number n<=32000, calculate the lowest number from
    the interval [1,n] with the biggest number of divisors.
*)
open System
printf " n="
let n=Console.ReadLine() |> int
let rec nrDiv nrDv div x=
    match div<=x with
    | false -> nrDv
    | true -> match x%div with
              | 0 -> nrDiv (nrDv+1) (div+1) x
              | _ -> nrDiv nrDv (div+1) x

let nrOfDivisors=List.map (fun x -> nrDiv 1 2 x) [2..n]
printfn "The list with the number of divisors for each number: %A" nrOfDivisors
let maximNrOfDivisors=List.max nrOfDivisors
printfn "The maxim number of divisors =%i" maximNrOfDivisors
let lowestNumber=List.findIndex (fun x -> x=maximNrOfDivisors) nrOfDivisors
printfn "The lowest number =%i" (lowestNumber+2)
