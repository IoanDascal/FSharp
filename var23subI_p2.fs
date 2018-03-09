open System
printf "Dati a="
let a=int(System.Console.ReadLine())
printf "Dati b="
let b=int(System.Console.ReadLine())
let rec calcul a b c=
    match ((a%2)*(b%2)) with
    | 0 -> match (a%2+b%2) with
           | 0 -> calcul (a*(a%2)+(1-a%2)*(a/2)) (b*(b%2)+(1-b%2)*(b/2)) (c+1)
           | _ -> calcul (a*(a%2)+(1-a%2)*(a/2)) (b*(b%2)+(1-b%2)*(b/2)) c
    | _ -> c

let res=calcul a b 0
printfn "%i" res
printfn ""