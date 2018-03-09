open System.IO
let input=File.OpenText("../nrVar264.txt")
let citireLinie (sr:StreamReader)=
    let sir=input.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir
let n=int((citireLinie input).[0])
let vector=Array.map int (citireLinie input)
let vectorInit=vector
let sterge (arr:int[]) i j=
    let nou=Array.append arr.[..i] arr.[j..]
    nou
let test=sterge vector 3 6
printfn "%A" test
let rec elimina (arr:int[]) n i=
    match i>=n with
    | true -> arr
    | false -> match arr.[i]=arr.[i+1] with
               | false -> elimina arr n (i+1)
               | true -> elimina (sterge arr i (i+2)) (n-1) i

let final= elimina vectorInit (n-1) 0
printfn "%A" final