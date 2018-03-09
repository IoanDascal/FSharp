open System.IO
let input=File.OpenText("../nrVar274.txt")
let citireLinie (input:StreamReader)=
    let sir=input.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir
let n=(citireLinie input).[0] |>int 
let numere=(citireLinie input) |>Array.map float
let diferente=[for i in 1..n-1 do
                   yield(int(floor(numere.[i])-floor(numere.[i-1])))]
let maxim=List.min diferente
printfn "maxim=%i" maxim