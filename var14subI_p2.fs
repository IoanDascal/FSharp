open System
printf "Dati x="
let x=int(System.Console.ReadLine())
let rec calculC y c=
    match y with
    | 0 -> c
    | _ -> match y%10>c with
            | true -> calculC (y/10) (y%10)
            | false -> calculC (y/10) c
let rec calcul x n=
    match x with
    | 0 -> n
    | _ -> let c=calculC x 0
           printf "Dati x="
           let x=int(System.Console.ReadLine())
           calcul x (n*10+ c)

let res=calcul x 0
printfn "%i" res
            