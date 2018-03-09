open System
printf "Dati un numar real a="
let a=float(System.Console.ReadLine())
let numitor=10000000
let numarator=int(a*float(numitor))
let rec cmmmdc a b=
    match a=0 || b=0 with
    | true -> a+b
    | false -> match a>b with
               | true -> cmmmdc (a%b) b
               | false -> cmmmdc a (b%a)
let dc=cmmmdc numarator numitor 
printfn "Fractia ireductibila este: %i/%i" (numarator/dc) (numitor/dc)
