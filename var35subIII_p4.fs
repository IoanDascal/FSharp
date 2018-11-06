(*
    a. Write a function sumOfDivisors : int -> int that 
returns the sum of all non-trivial and positive divisors.
    b. Using the function sumOfDivisors, print in increasing order
the sums of divisors for n integer numbers.
*)

open System
printf "Enter n="
let n=int(Console.ReadLine())

let sumOfDivisors x=
    let rec loop div sum=
        match div<=x/2 with
        | false -> sum
        | true -> if x%div=0 then
                      loop (div+1) (sum+div)
                  else
                      loop (div+1) sum
    loop 2 0

let sums=List.sort ([for i in 1..n do 
                         printf "Enter x="
                         let x=int(Console.ReadLine())
                         yield(sumOfDivisors x)])
printfn "%A" sums