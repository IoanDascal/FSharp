printf "Dati numarul de noduri n="
let n=int(System.Console.ReadLine())
let tati=[for i in 1.. n do 
              yield(printf "tati[%i]=" i
                    int(System.Console.ReadLine()))]
let rec calcul (ascendenti:int list)=
    printfn "tata=%i" tati.[ascendenti.[0]]
    printfn "asc=%A" ascendenti
    System.Console.ReadKey() |> ignore
    match tati.[ascendenti.[0]-1] with
    | 0 -> ascendenti
    |_ -> calcul (tati.[ascendenti.[0]-1]::ascendenti)
let rez=calcul [8]
printfn "%A" rez
          