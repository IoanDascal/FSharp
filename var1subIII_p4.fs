open System
printf "Dati numarul de elemente din lista n="
let n=int32(System.Console.ReadLine())
printfn "n=%i" n
let v=[| for i in 1..n do 
            printf "v[%i]=" i 
            yield int32(System.Console.ReadLine())|]
printfn "%A" v
printf "Dati un numar a="
let mutable a= 0
let countLower acc el=
    match el<a with
    | true -> acc+1
    | false -> acc

let frecvente=Array.create v.Length 0
printfn "frecv=%A" frecvente
for i in 0..frecvente.Length-1 do
    a <- v.[i]
    let res=Array.fold countLower 0 v
    Array.set frecvente i res
printfn "%A" frecvente

let suma=((frecvente.Length-1)*(frecvente.Length))/2
printfn "suma=%d" suma
let mesaj=if  Array.sum frecvente = suma then "DA" else "NU"
printfn "%s" mesaj