open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let matrice=[|for i in 0..n-1 do
                  yield ([|for j in 0..n-1 do
                               yield ((i+1)*(j+1)%10)|])|]

printfn "%A" matrice