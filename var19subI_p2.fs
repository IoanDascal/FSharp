open System
printf "Dati a="
let a=int(System.Console.ReadLine())
printf "Dati b="
let b=int(System.Console.ReadLine())
let x=a/10%10*10+a%10
let y=b/10%10*10+b%10
let rec calcul x y=
    match x>y with
    | true -> printfn ""
    | false -> match x/10=x%10 with
               | false -> calcul (x+1) y
               | true -> printf "%i" (x%10)
                         calcul (x+1) y
let res=calcul x y
