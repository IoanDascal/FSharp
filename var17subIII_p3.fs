open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let vector=[for i in 1..n do yield int(System.Console.ReadLine())]
let a=vector.[0]
let b=vector.[n-1]
let swap (x,y)=(y,x)
let interschimba=if a>b then swap (a,b) else (a,b)
let mic=fst interschimba
let mare=snd interschimba
let nr=List.countBy (fun x -> x>=mic && x<=mare) vector
printfn "Sunt %i numere intre %i si %i." (snd nr.[0]) mic mare
