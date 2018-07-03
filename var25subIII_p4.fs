(*
    Given a decimal number a with maximum two digits at the whole part and
maximum seven digits at the fractional part, write a programme to convert 
number a to an irreducible fraction.
*)
open System
printf "Enter a real number a="
let a=float(Console.ReadLine())
let denominator=10000000
let numerator=int(a*float(denominator))
let rec GCD a b=
    match a=0 || b=0 with
    | true -> a+b
    | false -> match a>b with
               | true -> GCD (a%b) b
               | false -> GCD a (b%a)
let greatestCommonFactor=GCD numerator denominator 
printfn "The irreducible fraction is: %i/%i" (numerator/greatestCommonFactor) (denominator/greatestCommonFactor)
