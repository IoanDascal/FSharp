open System
printf "Dati x="
let x=int(System.Console.ReadLine())
printf "Dati y="
let y=int(System.Console.ReadLine())
let swap (y,x)=(x,y)
let interschimbare=if x<y then swap (x,y) else (x,y)
printfn "%i" (fst interschimbare)
let a=fst interschimbare
let b=snd interschimbare
let rec afisare a b=
    match a>=b with
    | false -> printf ""
    | true -> printf "A"
              afisare (a-b) b
              printf "B"

let res = afisare a b