open System
printf "Dati x="
let x=int(System.Console.ReadLine())
let rec calcul x y=
    match x with
    | 0 -> y
    | _ -> let rec primaCifra x=
               match x>9 with
               | false -> x
               | true -> primaCifra (x/10)
           let y=y*10+primaCifra x
           printf "Dati x="
           let x=int(System.Console.ReadLine())
           calcul x y

let res=calcul x 0
printfn "%i" res