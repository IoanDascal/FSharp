open System
printf "Dati n="
let n=Console.ReadLine() |> int
let matrice=[|for i in 0..n-1 do
                  yield ([|for j in 0..n-1 do
                               if i=j || n-i-1=j then yield 0
                                   else if j>i && j<n-i-1 then yield 1
                                            else if j<i && j>n-i-1 then yield 2
                                                     else yield 3|])|]

for linie in matrice do
    printfn "%A" linie