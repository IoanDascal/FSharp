printf "Dati a="
let a=int(System.Console.ReadLine())
let rec calcul b k=
    match b>=a with
    | false -> (b,k)
    | true -> calcul (b-a) (k+1)
let res=calcul ((a+1)*(a+2)/2) 0
printfn "%A" res
