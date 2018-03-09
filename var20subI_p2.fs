open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let rec calcul a b m n=
    printf "a=%i    " a
    printf "b=%i    " b
    printf "m=%i    " m
    printfn "n=%i" n
    match n>0 with
    | false -> m 
    | true -> if a>b then
                  calcul b (n/10%10) (m*10+b) (n/10)
              else 
                  calcul a (n/10%10) m (n/10)

let res=calcul (n%10) (n/10%10) (n%10) n
printfn "%i" res
        