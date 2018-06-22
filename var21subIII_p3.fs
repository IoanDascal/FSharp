(*
    Given a natural number n, calculate the difference between
the biggest prime number lower than n(p1) and the lowest prime number
bigger than n(p2). 
   p1 <= n <= p2
*)
open System
printf "Enter n="
let n =int(Console.ReadLine())

let isPrime n=
    let rec loop i=
        match i<=n/2 with
        | false -> true
        | true -> match n%i with
                  | 0 -> false
                  | _ -> loop (i+1)
    loop 2

let p1 = 
    let rec loop nr=
        match isPrime nr with
        | true -> nr
        | false -> loop (nr-1)
    loop n
printfn "p1=%i" p1
let p2 =
    let rec loop nr=
        match isPrime nr with
        | true -> nr
        | false -> loop (nr+1)
    loop n
printfn "p2=%i" p2
printfn "p2-p1=%i" (p2-p1)