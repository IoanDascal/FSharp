open System
printf "Dati n="
let n=int32(System.Console.ReadLine())
printf "Dati m="
let m=int32(System.Console.ReadLine())
let A=Array2D.init<int> n m (fun row col -> if row>col then row+1 else col+1)
printfn "%A" A