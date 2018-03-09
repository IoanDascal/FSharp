open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let sumaDiv x=
    let rec suma sum div x=
        match div with
        | 1 -> sum+1
        | div -> match x%div with
                 | 0 -> suma (sum+div) (div-1) x
                 | _ -> suma sum (div-1) x
    suma 0 x x

for i in 1..n do
    printf "Dati x="
    let x=int(System.Console.ReadLine())
    if (sumaDiv x=x+1) then printfn "Numarul %i este prim." x
        else printfn "Numarul %i nu este prim." x