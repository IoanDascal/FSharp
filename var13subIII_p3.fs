open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let rec grupa k n acc=
    match acc<n with
    | false -> k-1
    | true -> grupa (k+1) n (acc+k)

let test= grupa 1 n 0
let suma=(test*(test+1))/2
let nrCautat=test-suma+n
printfn "%i" nrCautat