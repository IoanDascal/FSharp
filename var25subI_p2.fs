open System
printf "Dati a="
let a =int(System.Console.ReadLine())
printf "Dati b="
let b=int(System.Console.ReadLine())
printf "Dati c="
let c=int(System.Console.ReadLine())
let swap (x,y)=(y,x)
let compar=if a>b then swap (a,b) else (a,b)
let rec afisare a b c=
    match a<=b with
    | true -> if a%c=0 then printf "%i  " a
              afisare (a+1) b c 
    | false -> ()
let res=afisare (fst compar) (snd compar) c 
printfn ""