open System.IO
let input=File.OpenText("../nrVar224.txt")
let citireLinie (streamReader:StreamReader)=
    let linie=streamReader.ReadLine()
    let linie=linie.Replace(System.Environment.NewLine," ")
    let linie=linie.Split([|' '|])
    linie

let rec detPutere2 a b putere=
    if putere<=b then detPutere2 a b (putere*2)
        else if putere/2>=a then (putere/2)
            else 0
let nr=((citireLinie input) |> Array.map int).[0]
for i in 1..nr do
    let ab=(citireLinie input) |> Array.map int
    let a=ab.[0]
    let b=ab.[1]
    let putere2=detPutere2 a b 1
    printf "%i " putere2
printfn ""