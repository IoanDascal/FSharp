(*
    Given an integer number x, write a function primeNumber : int -> int
to calculate the lowest prime number bigger than x.
*)
let isPrime x=
    let rec loop i=
        match i<=x/2 with
        | false -> true
        | true -> match x%i with
                  | 0 -> false
                  | _ -> loop (i+1)
    loop 2

printf "Enter x="
let x=int(System.Console.ReadLine())
let rec primeNumber x=
    if (isPrime x) then x
        else
            primeNumber (x+1)
let res=primeNumber (x+1)
printfn "The lowest prime number bigger than x is=%i" res