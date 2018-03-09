//Read from file
open System.Net
open System.IO

//let strip chars=String.map (fun c -> if Seq.exists((=)c) chars then ' ' else c)

let citire=
    use input=File.OpenText("test.txt")
    let str=input.ReadToEnd()
    let str=str.Replace(System.Environment.NewLine," ")
    printfn "str=%s" str
    let res=str.Split([|' '|])
    res

let sir=citire 
let lung=sir.Length
printfn "%d" lung
printfn "%A" sir
printf "Dati un numar n="
let n=int32(System.Console.ReadLine())
printfn "n=%d" n

let numere=sir.[..(lung-2)] |> Array.map System.Int32.Parse
                            |> Array.filter (fun x -> x%n=0)
for num in numere do
    printf "%i  " num