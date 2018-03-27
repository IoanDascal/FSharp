open System
printf "Dati n="
let n=Console.ReadLine()
let sir=n.ToCharArray()
printfn "%A" sir
let matrice=[|for i in 0..5 do
                  yield ([|for j in 0..5 do
                               match i=j with
                               | true -> yield 0
                               | false -> match i<j with
                                          | true ->  yield (int(n.[5-i])-48)
                                          | false -> yield (int(n.[5-j])-48)
                          |])
             |]

for i in 0..5 do
    for j in 0..5 do
        printf "%i " matrice.[i].[j]
    printfn ""
