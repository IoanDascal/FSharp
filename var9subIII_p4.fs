open System.IO
open System.Net
let citire =
    use input=File.OpenText("nrVar94.txt")
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res 

let numere=Array.filter (fun x -> x>=100 && x<1000) (Array.map (fun x -> int(x)) citire)
printfn "%A" numere
let rec cauta nrElem elem =
    match nrElem with
    | 2 -> printfn ""
    | _ -> if not (Array.exists (fun x -> x=elem) numere) then printf "%i " elem
                                                               cauta (nrElem+1) (elem-1)
                                                          else
                                                              cauta nrElem (elem-1)
let res=cauta 0 999
