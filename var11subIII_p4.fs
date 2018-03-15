(*
    a) Implement a function that computes the sum of all divisors
    for an integer number.
    b) Using the above function determine the prime numbers
    from a sequence of n integers.
*)
open System
printf " n="
let n=int(Console.ReadLine())
let sumOfAllDivisors x=
    let rec sum total divisor x=
        match divisor with
        | 1 -> total+1
        | divisor -> match x%divisor with
                     | 0 -> sum (total+divisor) (divisor-1) x
                     | _ -> sum total (divisor-1) x
    sum 0 x x

for i in 1..n do
    printf " x="
    let x=int(Console.ReadLine())
    if ((sumOfAllDivisors x)=x+1) then printfn "The number %i is prime." x
        else printfn "The number %i is not prime." x