open System
printf "Dati un numar n="
let n=int32(System.Console.ReadLine())
printfn "n=%i" n

printf "Dati un numar m="
let m=int32(System.Console.ReadLine())
printfn "m=%i" m

let matrice=
       Array2D.init<int> n m (fun row col -> if row<col then  (row+1)
                                                        else (col+1))
printfn "%A" matrice
