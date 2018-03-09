open System.IO 
let citire numeFisier=
    use input=File.OpenText(numeFisier)
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir 
let numere1=List.ofArray (Array.map int (citire "../nrVar204I.txt"))
let numere2=List.ofArray (Array.map int (citire "../nrVar204II.txt"))
let final=List.choose (fun x -> match (List.exists (fun y -> y=x) numere1) with
                                | true -> Some(x)
                                | false -> None) numere2
printfn "%A" final
