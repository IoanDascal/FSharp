open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let rec calcul s n=
    match n with 
    |0 -> s
    | _ -> match n%10<s with
           | true -> calcul (n%10) (n/10)
           | false -> calcul -1 (n/10)

let res=calcul 10 n
printfn "%i" res