(*
    Create a function scif : int -> int to calculate the sum of
digits from an integer number n.
*)

open System
printf "Enter an integer n="
let n=int(Console.ReadLine())
let scif n=
    let rec innerLoop n sum=
        match n with
        | 0 -> sum
        | _ -> innerLoop (n/10) (sum+n%10)
    innerLoop n 0

let res=scif ((scif n)+(scif n))
printfn "%i" res