open System.IO
let citire=
    use input=File.OpenText("nrVar154.txt")
    let sir=input.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res

let numere=Array.map (fun x -> int(x)) (citire)
printfn "%A" numere
let impare=Array.choose (fun x -> if x%2=1 then Some x else None) numere
printfn "%A" impare
printf "Ultimele doua : %i si %i" impare.[impare.Length-2] impare.[impare.Length-1]
printfn ""
