open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let sir=[|for i in 1..n do
              printf "Dati vec[%i]=" i
              yield int(System.Console.ReadLine())|]

printfn "%A" sir
let suma=Array.sum sir
let lungime=sir.Length
let rec afiseaza sumaSir lung=
    match lung with
    | 1 -> printfn "%i" sir.[0]
    | _ -> printfn "%i" sumaSir
           afiseaza (sumaSir-sir.[lung-1]) (lung-1)

let afis=afiseaza suma lungime