(*
    Define a data type to describe a circle. Create a record x of
type Circle and calculate the diameter, circumference and area.
*)

open System
type Circle=
    {
        abscissa:int;
        ordinate:int;
        radius:float
    }
printf "Enter the abscissa for the center of a circle:"
let abs=int(Console.ReadLine())
printf "Enter the ordinate for the center of a circle:"
let ord=int(Console.ReadLine())
printf "Enter the radius of a circle:"
let rad=float(Console.ReadLine())
let x={abscissa=abs;ordinate=ord;radius=rad}
let diameter=2.0*x.radius
printfn "The diameter of the circle is d=%f" diameter
let circumference=2.0*Math.PI*x.radius
printfn "The circumference of the circle is =%f" circumference
let area=Math.PI*x.radius*x.radius
printfn "The area of the circle is =%f" area
let distance=Math.Sqrt(float(x.abscissa*x.abscissa)+float(x.ordinate*x.ordinate))
printfn "The distance from the center of the coordinate system is =%f" distance
