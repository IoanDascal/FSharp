open System
type Dreptunghi=
    {
        a:float;
        b:float;
        aria:float;
    }
printf "Dati a="
let a=float(System.Console.ReadLine())
printf "Dati b="
let b=float(System.Console.ReadLine())
let d={a=a;b=b;aria=a*b}
printfn "Aria dreptunghiului =%f" d.aria