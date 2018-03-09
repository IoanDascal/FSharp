open System.IO
let citire numeFisier=
    use input=File.OpenText(numeFisier)
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir
let lista1=List.ofArray (Array.map int (citire "../nrVar193I.txt"))
let lista2=List.ofArray (Array.map int (citire "../nrVar193II.txt"))
let merge xs ys=
    let rec loop xs ys=
        seq{
            match xs,ys with
            | [],ys -> yield! ys
            | xs,[] -> yield! xs
            | x::xs,y::ys -> match x<y with
                             | true -> yield x
                                       yield! loop xs (y::ys)
                             | false -> match x>y with
                                        | true -> yield y
                                                  yield! loop (x::xs) ys
                                        | false -> yield x
                                                   yield! loop xs ys
        }
    loop xs ys |> List.ofSeq
let final=merge lista1 lista2
printfn "%A" final