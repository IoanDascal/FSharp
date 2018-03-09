open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let rec sub n k=
    match n with
    | 0 -> printf ""
    | _ -> printf "%i " (n*k)
           sub (n-1) k
let res= sub n k