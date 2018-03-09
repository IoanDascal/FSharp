open System
type Fractie=
    {
        x:int;
        y:int
    }

let citeste msg:string=
    printf "Dati %s = " msg
    let a=System.Console.ReadLine()
    a

let x1=int32(citeste "f1.x")
let y1=int32(citeste "f1.y")
let f1={x=x1;y=y1}
let x2=int32(citeste "f2.x")
let y2=int32(citeste "f2.y")
let f2={x=x2;y=y2}
let f3={x=f1.x*f2.y + f1.y*f2.x;y=f1.y*f2.y}
printfn "Numarator=%i" f3.x
printfn "Numitor=%i" f3.y
let rec cmmdc x y=
    if y=0 then
        x
        else
            cmmdc y (x%y) 

let div=cmmdc f3.x f3.y
let f={x=f3.x/div;y=f3.y/div}
printfn "Numarator=%i" f.x
printfn "Numitor=%i" f.y