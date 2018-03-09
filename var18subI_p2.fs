open System
printf "Dati x="
let x=Console.ReadLine() |> int
printf "Dati y="
let y=int(System.Console.ReadLine())
let swap (x,y)=(y,x)
let interschimbare=if x>y then swap (x,y) else (x,y)
let a=if (fst interschimbare)%2=0 then ((fst interschimbare)+1 ) else (fst interschimbare)
let rec afisare x y=
    match x<=y with
    | false -> printfn ""
    | true -> printf "*"
              afisare (x+2) y

let res=afisare a (snd interschimbare)