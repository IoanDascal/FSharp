open System
printf "Dati a="
let a=int(System.Console.ReadLine())
printf "Dati b="
let b=int(System.Console.ReadLine())

let rec numara n c=
    match n with
    | 0 -> c
    | _ -> match n%2 with 
           | 1 -> numara (n/10) (c+1)
           | _ -> numara (n/10) c
let rec calcul a b k=
    match a=b+1 with
    | true -> k 
    | false -> let c= numara a 0
               match c with
               | 0 -> calcul (a+1) b k
               | _ -> calcul (a+1) b (k+1)
    

let res=calcul a b 0
printfn "%i" res
