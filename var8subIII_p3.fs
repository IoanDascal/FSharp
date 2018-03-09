open System.IO
open System.Net
let input=File.OpenText("nrVar83.txt")
let citireLinie (input:StreamReader)=
    let sir=input.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res

let isPerfectSquare (x:int)=
    let y=int(round (sqrt (float x)))
    y*y=x 
let linie1=citireLinie input
let n=int(linie1.[0])
printfn "%i" n
let linie2=(Array.map (fun x -> int(x)) (citireLinie input)) |> Array.choose (fun x -> match (isPerfectSquare x) with 
                                                                                       | false -> None 
                                                                                       | true -> Some(x)) 
                                  
printfn "%A" linie2
for i in 0..linie2.Length-2 do printf "%i + " linie2.[i]
printf "%i = %i" linie2.[linie2.Length-1] (Array.sum linie2)
printfn ""


