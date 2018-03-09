open System
printf "Dati numarul de noduri n="
let n=int(System.Console.ReadLine())
let tati=[for i in 1..n do
              yield (printf "tata[%i]=" i
                     int(System.Console.ReadLine()))]
printfn "%A" tati
let radacina= tati |> List.findIndex (fun x -> x=0)
printfn "Nodul radacina este= %i" (radacina+1)
printfn "Descendentii nodului 7 sunt :"
//tati |> List.iteri (fun i x -> if x=7 then printf "%i " (i+1)
  //                                 else printf "")
let descendenti=[for i in 0..n-1 do
                     if tati.[i]=7 then yield (i+1)]
printfn "%A" descendenti
