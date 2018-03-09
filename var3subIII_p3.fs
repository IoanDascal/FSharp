open System.IO
open System.Net

let citire=
    use input=File.OpenText("num.txt")
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res
 
let sir =citire
printfn "%A" sir
let numere=sir.[..sir.Length-1] |> Array.map (fun x -> float(x))
                                |> Array.filter (fun x -> x>100000.0)

let nr=Array.length numere
if nr=0 then printfn "Nu exista"
    else
        let res=Array.sort numere
        printfn "%A" res
        let suma=Array.sum res
        printfn "sum=%f" (suma-float(res.Length)*100000.0)
