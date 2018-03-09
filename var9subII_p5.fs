open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let matrice=[|for i in 0..n-1 do
                  yield [|for j in 0..n-1 do
                              yield ( printf "mat[%i,%i]=" i j
                                      int(System.Console.ReadLine()))|]|]

for i in 0..n-1 do
    for j in 0..n-1 do
        printf "%i  " matrice.[i].[j]
    printfn ""

for i in 0..n-1 do printf "%i " matrice.[0].[i]
for i in 1..n-1 do printf "%i " matrice.[i].[n-1]
for i in n-2.. -1 ..0 do printf "%i " matrice.[n-1].[i]
for i in n-2.. -1 ..1 do printf "%i " matrice.[i].[0]