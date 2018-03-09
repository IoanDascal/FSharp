open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let frecvente=Array.create<int> 10 0
for i in 0..n-1 do 
    printf "Dati x="
    let x=int(System.Console.ReadLine())
    frecvente.[x] <- frecvente.[x]+1
printfn "%A" frecvente
for i in 0..9 do
    for j in 0..frecvente.[i]-1 do
        printf "%i " i