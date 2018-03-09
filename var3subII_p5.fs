open System
printf "Dati numarul de linii si coloane n="
let n=int32(System.Console.ReadLine())
let matrice=Array2D.init<int> n n (fun row col -> if row=col then 0 else n-col)
printfn "%A" matrice