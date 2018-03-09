open System
printf "Dati numarul de noduri n="
let n=int32(System.Console.ReadLine())
let vectorTati:int32 list=[for i in 1..n do 
                               printf "v[%i]=" i
                               yield int32(System.Console.ReadLine())]
printfn "Vectorul de tati este : %A" vectorTati
let frunze=List.filter (fun x -> not (List.contains x vectorTati)) [1..n]
printfn "Frunzele sunt : %A" frunze
printfn "Arborele are %i frunze" frunze.Length
printfn "Radacina arborelui este %i" ((List.findIndex (fun elem -> elem=0) vectorTati)+1) 