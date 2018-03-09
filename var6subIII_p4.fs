open System.IO
open System.Net
let citire=
    use input=File.OpenText("nrVar64.txt")
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res 
let vector=citire
printfn "%A" vector
let numere= Array.map (fun x -> int(x)) vector
printfn "numere : %A" numere
//       Varianta 1
let mutable frecv=1
let diferite=List.append [for i in 0..numere.Length-2 do
                              if numere.[i]<> numere.[i+1] then yield (numere.[i],frecv);frecv <- 1
                                  else frecv <- frecv+1  ] [(numere.[numere.Length-1],frecv)]
printfn "diferite : %A" diferite
 
 //   Varianta 2
let dist=
    Seq.ofArray numere
    |> Seq.distinct
    |> Seq.toArray
     
printfn "distincte : %A" dist
let count value aray=
    Seq.where (fun x -> x=value) aray
    |> Seq.length

let frecvente=[|for i in 0..dist.Length-1 do
                    yield count dist.[i] numere|]
printfn "frecvente : %A" frecvente
let rezultat=[|for i in 0..dist.Length-1 do yield (dist.[i],frecvente.[i])|]
printfn "rezultat : %A" rezultat