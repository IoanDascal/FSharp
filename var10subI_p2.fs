open System
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati k="
let k=int(System.Console.ReadLine())
let rec calcul n k p nr=
    match n<>0 && k<>0 with
    | false -> nr
    | true -> match n%2 with
              | 0 -> calcul (n/10) (k-1) p nr 
              | _ -> calcul (n/10) k (p*10) (nr+(n/10)%10*p )

let res=calcul n k 1 0
printfn "%i" res