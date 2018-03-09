open System.IO
open System.Net

let citire=
    use input=File.OpenText("nr.txt")
    let str=input.ReadToEnd()
    let str=str.Replace(System.Environment.NewLine," ")
    let res=str.Split[|' '|]
    res

let sir=citire
let numere=sir.[..sir.Length-1] |> Array.map System.Int32.Parse
                                |> Array.filter (fun x -> x>0)

let nr=Array.length numere
printfn "%A" nr
if nr=0 then printfn "Nu exista"
    else
        let res=Array.sort numere
        printfn "%A" res