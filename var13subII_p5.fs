open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let (|MaiMic|Egal|MaiMare|) (a, b)=
    match a<b with
    | true -> MaiMic
    | false -> match a=b with
               | true -> Egal
               | false -> MaiMare
let matrice=[|for i in 0..n-1 do
                  yield ([|for j in 0..n-1 do
                               match ((i+j), (n-1)) with
                               | MaiMic -> yield (j+1)
                               | Egal -> yield 0
                               | MaiMare -> yield (n-i)|])|]

let res= matrice
printfn "%A" res