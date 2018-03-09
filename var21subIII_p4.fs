open System.IO
let input=File.OpenText("../nrVar214.txt")
let citireLinie (streamReader:StreamReader)=
    let sir=streamReader.ReadLine() 
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir

let nk=citireLinie input
let n=int(nk.[0])
let k=int(nk.[1])
let numere=Array.map int (citireLinie input)
let sume=Array.mapi (fun i x -> if i<=n-k then (Array.sum numere.[i..(i+k-1)]) else x) numere
let maxim=Array.max sume
let index=Array.findIndex (fun x -> x=maxim) sume
printfn "Secventa de k=%i numere cu suma maxima=%i incepe din pozitia=%i" k maxim index
