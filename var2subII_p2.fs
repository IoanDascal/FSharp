(*
    Given the sides a,b,c of a triangle calculate the:
 - perimeter P of the triangle,
 - area A using Heron's formula,
 - circumradius R,
 - inradius r.
*)
open System
type Triangle=
    {
        a:float32;
        b:float32;
        c:float32
    }
printf "Enter side x="
let x=float32(Console.ReadLine())
printf "Enter side y="
let y=float32(Console.ReadLine())
printf "Enter side z="
let z=float32(Console.ReadLine())
let tr={a=x;b=y;c=z}
let P=tr.a+tr.b+tr.c;
let A=sqrt(P/2.0f*(P/2.0f-tr.a)*(P/2.0f-tr.b)*(P/2.0f-tr.c))
let R=sqrt(tr.a*tr.a*tr.b*tr.b*tr.c*tr.c/(P*(tr.b+tr.c-tr.a)*(tr.a+tr.c-tr.b)*(tr.a+tr.b-tr.c)))
let r=sqrt((tr.b+tr.c-tr.a)*(tr.a+tr.c-tr.b)*(tr.a+tr.b-tr.c)/(4.0f*P))
printfn "a=%f" tr.a
printfn "b=%f" tr.b
printfn "c=%f" tr.c 
printfn "P=%f" P
printfn "A=%f" A
printfn "R=%f" R
printfn "r=%f" r