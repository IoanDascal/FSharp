open System
printf "Dati a="
let a=int(System.Console.ReadLine())
printf "Dati n="
let n=int(System.Console.ReadLine())
let rec calcul a n=
    match n with
    | 1 -> a
    | _ -> match i%2=0 with
           | true -> calcul (a-n*n) (n-1)
           | false -> calcul (a+n*n) (n-1)

let res=calcul a n
printfn "%i" res
