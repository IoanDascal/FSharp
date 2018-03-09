open System
printf "Dati numarul de noduri n="
let n=int(System.Console.ReadLine())
let tati=[for i in 1..n do yield(printf "tati[%i]=" i
                                 int(System.Console.ReadLine()))]

printfn "%A" tati
let frecvente=tati |> List.countBy id       //Seq.countBy id |> Seq.toList
printfn "%A" frecvente
printf "Nodurile care au 2 descendenti sunt:"
for i in 0..frecvente.Length-1 do
    if (snd frecvente.[i])=2 then
        printf "%i  " (fst frecvente.[i])
printfn ""