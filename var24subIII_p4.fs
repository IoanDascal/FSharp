open System.IO
let input=File.OpenText("../nrVar244.txt")
let citireLinie (istr:StreamReader)=
    let sir=istr.ReadLine()
    let sir=sir.Split([|' '|])
    sir
let n=(Array.map int (citireLinie input)).[0]
let vector=[|for i in 1..n do
                 yield((Array.map int (citireLinie input)).[0])|]
let ab=Array.map int (citireLinie input)
let primul=Array.find (fun x -> x>=ab.[0]) vector
printfn "%i" primul