open System.IO
open System.Net
open System.Collections.Generic
let mutable harta=new Dictionary<int,int>()
let stream=new StreamReader("nrVar104.txt")
let mutable valid=true
let res=while valid do
            let linie=stream.ReadLine()
            match linie with
            | null -> valid <- false
            | _ -> let linie=linie.Replace(System.Environment.NewLine," ")
                   let linie=linie.Split([|' '|])
                   let vect=Array.map (fun x -> int(x)) linie
                   match harta.ContainsKey(vect.[0]) with
                   | false -> let harta=harta.Add(vect.[0],(vect.[1]*vect.[2]))
                              printfn ""
                   | true -> let sum=harta.[vect.[0]]
                             let sum1=sum+vect.[1]*vect.[2]
                             harta.[vect.[0]] <- sum1
        
printfn "%A" harta
