open System
printf "Dati a="
let a=int(System.Console.ReadLine())
printf "Dati b="
let b=int(System.Console.ReadLine())
printf "Dati n="
let n=int(System.Console.ReadLine())
let rec loop i a=
    match i=n || a=0 with
    | true -> printf ".."
    | false -> printf "%i" (a*10/b)
               loop (i+1) (a*10%b)
let calcul a b n=
    match b with
    | 0 -> printf "gresit"
    | _ -> printf "%i" (a/b)
           match n>0 && a%b<>0 with
           | false -> printfn ""
           | true -> printf ","
                     loop 0 (a%b)

let res=calcul a b n
printfn ""
