open System.IO
let input=File.OpenText("../nrVar294.txt")
let citireLinie (istr:StreamReader)=
    let sir=istr.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir

let mn=(citireLinie input) |> Array.map int
let m=mn.[0]
let n=mn.[1]
let A=(citireLinie input) |> Array.map int
printfn "s1=%i" (Array.sum A.[0..0])
let B=(citireLinie input) |> Array.map int
let mutable j=0
let redus=[|for i in 0..n-1 do
                yield(let rec sum j k=
                          match Array.sum A.[j..j+k]<B.[i] with
                          | true -> sum j (k+1)
                          | false -> k
                      let k1=sum j 0
                      j <- j+k1+1
                      if Array.sum A.[(j-k1-1)..(j-1)]=B.[i] then Some B.[i]
                          else
                              None)|]
let daNu=Array.forall (fun x -> x<>None) redus
if daNu then printfn "DA"
    else printfn "Nu"