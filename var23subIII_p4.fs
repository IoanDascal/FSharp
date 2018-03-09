open System.IO
let input=File.OpenText("../nrVar234.txt")
let citireLinie (stream:StreamReader)=
    let sir=stream.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir
let intersectie (a:int,b:int) (c:int,d:int )=
    if c>b || d<a then None
        else Some(a,b)
let test =intersectie (3,7) (8,11)
let n=int((citireLinie input).[0])
let listaIntervale=[for i in 1..n do
                        let ab=citireLinie input
                        let a=int(ab.[0])
                        let b=int(ab.[1])
                        yield (a,b)]
                        
printfn "%A" listaIntervale
let res=[for i in 0..n-1 do
             yield((List.choose (fun x -> (intersectie x (fst listaIntervale.[i],snd listaIntervale.[i])))  listaIntervale) |>List.length)]
List.iteri (fun i x -> if x=1 then printfn "%A" listaIntervale.[i]) res 