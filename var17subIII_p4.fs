open System.IO
let input=try
             File.OpenText "nrVar174.txt"
          with
              | :? FileNotFoundException -> printfn "Error: File nrVar174.txt not found";exit(1)

let n=int(input.ReadLine())   //  NU am nevoie de n
let citeste=
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res 

let numere=citeste |> Array.map int
let poz=Array.countBy (fun x -> x<numere.[0]) numere
let res=
    match fst poz.[0] with
    | true -> printfn "%i" (snd poz.[0]+1)
    | false -> printfn "%i" (snd poz.[1]+1)

res 