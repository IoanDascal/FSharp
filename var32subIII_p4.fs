open System.IO
let input=File.OpenText("nrVar324.txt")
let citireLinie (isr:StreamReader)=
    let sir=isr.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir

let numere=Array.map int (citireLinie input)
let nr2Cifre=Array.filter (fun x -> abs x>=10 && abs x<100) numere
let minim=Array.min nr2Cifre
let nr2cif=Array.filter (fun x -> x<> minim) nr2Cifre
let minim1=Array.min nr2cif
printfn "%i  %i" minim minim1