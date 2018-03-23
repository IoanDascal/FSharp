(*
    p1 and p2 are end points of a line segment, and p3 is the midpoint
    of the segment. Calculate the coordinates x and y of the midpoint p3.
*)
open System
type Point=
    {
        x:float;
        y:float;
    }

let readValue msg:string=
    printf "%s" msg
    let a=Console.ReadLine()
    a

let a=float(readValue " a=")
printfn "%f" a
let b=float(readValue " b=")
printfn "%f" b
let p1={x=a;y=b}
let c=float(readValue " c=")
printfn "%f" c
let d=float(readValue " d=")
printfn "%f" d
let p2={x=c;y=d}
let p3={x=(p1.x+p2.x)/2.0;y=(p1.y+p2.y)/2.0}
printfn "p3.x=%f" p3.x
printfn "p3.y=%f" p3.y