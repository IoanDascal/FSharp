open System.IO
open System.Net

let citire=
    use input=File.OpenText("nrvar4.txt")
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res

let sir=citire
let numere=sir.[..sir.Length-1] |> Array.map (fun x -> int32(x)) 
                                |> Array.filter (fun x -> x<100)

if numere.Length=0 then printfn "Nu exista"
    else
        let res= Array.sortDescending numere
        printfn "%A" res