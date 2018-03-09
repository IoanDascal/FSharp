open System.IO
let input=File.OpenText("../nrVar284.txt")
let citireLinie (inputReader:StreamReader)=
    let sir=inputReader.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir
//printf "Dati a="
//let a=int(System.Console.ReadLine())
let primul x=
    let rec loop i=
        match x%i=0 with
        | true -> i
        | false -> loop (i+1)
    loop 2
let n=(citireLinie input).[0] |> int
let numere=Array.map int (citireLinie input)
let aproapePrim=[for i in 0..n-1 do
                     yield(let div=primul numere.[i]
                           let div1=primul (numere.[i]/div)
                           if numere.[i]=div*div1 then numere.[i]
                               else 0)]
let maxim=List.max aproapePrim
if maxim>0 then printfn "Cel mai mare numar aproape prim este =%i" maxim
    else printfn "Nu"