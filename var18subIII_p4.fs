open System.IO
let citire=
    use input=File.OpenText "nrVar184.txt"
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let res=sir.Split([|' '|])
    res 
let numere= citire |> Array.map int
printf "Dati k="
let k=int(System.Console.ReadLine())
let res=match Array.exists (fun x -> x=k) numere with
        | false -> printfn "Nu exista" 
        | true -> let numara=Array.countBy (fun x -> x<k) numere
                  printfn "%A" numara
                  match (fst numara.[0]) with
                  | false -> printfn "Pozitia este =%i" (snd numara.[0])
                  | true -> printfn "Pozitia este =%i" (snd numara.[1])

