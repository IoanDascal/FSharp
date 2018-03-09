open System.IO
let input=File.OpenText("../nrVar304.txt")
let citireLinie (isr:StreamReader)=
    let sir=isr.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir
let n=(citireLinie input).[0] |> int
let numere=(citireLinie input) |> Array.map float
let x=Array.map int numere
let xx=Array.distinct x
let nrIntervale=xx.Length
printfn "Sunt %i intervale" nrIntervale