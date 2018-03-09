open System
type Punct=
    {
        x:float;
        y:float;
    }

let citeste msg:string=
    printf "%s" msg
    let a=System.Console.ReadLine()
    a

let a=float(citeste "Dati a=")
printfn "%f" a
let b=float(citeste "Dati b=")
printfn "%f" b
let p1={x=a;y=b}
let c=float(citeste "Dati c=")
printfn "%f" c
let d=float(citeste "Dati d=")
printfn "%f" d
let p2={x=c;y=d}
let p3={x=(p1.x+p2.x)/2.0;y=(p1.y+p2.y)/2.0}
printfn "p3.x=%f" p3.x
printfn "p3.y=%f" p3.y