open System
printf "Dati un numar n="
let n=int32(System.Console.ReadLine())
let matrice=Array2D.init<int> n n (fun row col -> if row+col=n-1 then 0 else n-row)
printfn "%A" matrice