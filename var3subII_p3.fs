(*
    Implement simple operations with fractions.
*)
open System
type Fraction=
    {
        x:int;
        y:int
    }

printf "Enter f1.x="
let x1=int32(Console.ReadLine())
printf "Enter f1.y="
let y1=int32(Console.ReadLine())
let f1={x=x1;y=y1}
printf "Enter f2.x="
let x2=int32(Console.ReadLine())
printf "Enter f2.y="
let y2=int32(Console.ReadLine())
let f2={x=x2;y=y2}
let rec gcd x y=
    if y=0 then
        x
        else
            gcd y (x%y) 

///Addition 
let f3={x=f1.x*f2.y + f1.y*f2.x;y=f1.y*f2.y}
printfn "Numerator=%i" f3.x
printfn "Denominator=%i" f3.y

let div3=gcd f3.x f3.y
let f3i={x=f3.x/div3;y=f3.y/div3}
printfn "Numerator=%i" f3i.x
printfn "Denominator=%i" f3i.y

///Substraction
let f4={x=f1.x*f2.y - f1.y*f2.x;y=f1.y*f2.y}
printfn "Numerator=%i" f4.x
printfn "Denominator=%i" f4.y
let div4=gcd f4.x f4.y
let f4i={x=f4.x/div4;y=f4.y/div4}
printfn "Numerator=%i" f4i.x
printfn "Denominator=%i" f4i.y

///Multiplication
let f5={x=f1.x*f2.x;y=f1.y*f2.y}
printfn "Numerator=%i" f5.x
printfn "Denominator=%i" f5.y
let div5=gcd f5.x f5.y
let f5i={x=f5.x/div5;y=f5.y/div5}
printfn "Numerator=%i" f5i.x
printfn "Denominator=%i" f5i.y