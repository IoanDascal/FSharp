open System
printf "Dati x="
let x=int32(System.Console.ReadLine())
printf "Dati z="
let z=int32(System.Console.ReadLine())
let rec calcul y x=
    match x with
    | 0 -> y
    | _ -> calcul (y*10+x%10) (x/100)

let rec calculYZ (f,s )=
    match f*s>0 && f%10=s%10 with
    | false -> (f,s)
    | true -> calculYZ (f/10,s/10)

let scrie (f,s)=
    match f+s with
    | 0 -> printfn "1"
    | _ -> printfn "0"

let y=calcul 0 x
printfn "y=%i" y
let rez=calculYZ (y, z)
printfn "y=%i" (fst rez)
printfn "z=%i" (snd rez)
let final=scrie rez