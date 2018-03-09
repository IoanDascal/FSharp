open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let s= string n
let linie=[|for i in 0..s.Length-1 do
                yield (int(s.[s.Length-i-1])-48)|]
printfn "%A" linie
let matrice=[|for i in 0..s.Length-1 do yield linie|]
printfn "%A" matrice