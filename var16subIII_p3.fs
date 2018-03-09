open System
printf "Dati n="
let n=Console.ReadLine() |> int
printf "Dati k="
let k=Console.ReadLine() |> int
printfn "Dati elementele tabloului:"
let numere=[for i in 0..n-1 do
                yield (printf "numere[%i]=" i
                       int(System.Console.ReadLine())) ] 

printfn "%A" numere
let valideazaNumar nr k=
    match nr%k with
    | 0 -> nr%10=k
    | _ -> false

let res = List.choose (fun x -> if (valideazaNumar x k) then Some x else None) numere
printfn "Numerele cautate sunt: %A" res