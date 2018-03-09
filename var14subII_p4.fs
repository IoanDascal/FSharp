open System
printf "Dati numarul de noduri n="
let n=int(System.Console.ReadLine())
let tati=[for i in 0..n-1 do
              yield(printf "Dati nodul %i=" (i+1)
                    int(System.Console.ReadLine()))]
printfn "%A" tati
let radacina=List.findIndex (fun x -> x=0) tati
printfn "Nodul radacina este : %i" (radacina+1)
let frunze:int option list=[for i in 0..n-1 do
                                 if not (List.contains i tati) then yield (Some i)]
printfn "Nodurile frunza sunt:"
List.iter (fun x -> if Option.isSome x then printf "%A " <| Option.get x else ()) frunze 
printfn ""