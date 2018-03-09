open System.IO
open System.Net
let input=File.OpenText("nrVar84.txt")
let citire (input:StreamReader)=
    let sir=input.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res 

let nm=citire input
let n=int(nm.[0])
printfn "n=%i" n 
let m=int(nm.[1])
printfn "m=%i" m 
let a=List.ofArray (Array.map (fun x -> int(x)) (citire input))
let b=List.ofArray (Array.map (fun x -> int(x)) (citire input))
printfn "a= %A" a

printfn "b= %A" b
let merge ant xs ys=
    let rec loop ant xs ys=
        seq{
            match xs,ys with
            | [],ys -> yield! ys
            | xs,[] -> yield! xs
            | x::xs,y::ys -> match x<y with
                             | true ->  match ant with
                                        | -1 -> yield x
                                                yield! loop x xs (y::ys)
                                        | _ -> match ant%2=x%2 with
                                               | true -> yield! loop x xs (y::ys)
                                               | false -> yield x
                                                          yield! loop x xs (y::ys)
                             | false -> match ant with
                                        | -1 -> yield y 
                                                yield! loop y (x::xs) ys
                                        | _ -> match ant%2=y%2 with
                                               | true -> yield! loop y (x::xs) ys
                                               | false -> yield y
                                                          yield! loop y (x::xs) ys 
        }
    loop ant xs ys |> List.ofSeq

let final=merge -1 a b
printfn "%A" final