(*
    Write a function to compute the area, perimeter and
diagonal of a rectangle.
*)
open System
type Rectangle=
    {
        l:float;
        L:float;
        area:float;
        perimeter:float;
        diagonal:float
    }
printf "Enter l="
let a=float(Console.ReadLine())
printf "Enter L="
let b=float(Console.ReadLine())
let d={l=a;L=b;area=a*b;perimeter=2.0*(a+b);diagonal=sqrt(a*a+b*b)}
printfn "The area of rectangle  =%f" d.area
printfn "The perimeter of rectangle=%f" d.perimeter
printfn "The diagonal of rectangle=%f" d.diagonal