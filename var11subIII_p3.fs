open System.IO
let citireLinie=
    use input=File.OpenText("nrVar113.txt")
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir

let cit=citireLinie
let numere= Array.map (fun x -> int(x)) cit
let n=numere.[0]
printfn "n=%i" n
let mutable maxim=numere.[1]
for i in 1..n do
    if maxim < numere.[i] then maxim <- numere.[i]
                               printf "%i " maxim
                            else printf "%i " maxim
                          