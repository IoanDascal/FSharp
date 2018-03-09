open System
type Triunghi=
    {
        a:float;
        b:float;
        c:float;
        P:float
    }
let citeste msg:string=
    printf "Dati  %s"  msg
    let a=System.Console.ReadLine()
    a 

let a=float(citeste "a=")
let b=float(citeste "b=")
let c=float(citeste "c=")
let triunghi1={a=a;b=b;c=c;P=a+b+c}
printfn "a=%f" triunghi1.a
printfn "b=%f" triunghi1.b
printfn "c=%f" triunghi1.c 
printfn "P=%f" triunghi1.P