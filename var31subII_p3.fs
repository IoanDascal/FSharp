(*
    Define a data type to store the name and the manufacturing year of a car.
Calculate how old is a car.
*)

open System
type Car=
    {
        Name:string;
        ManufacturingYear:int  
    }
printf "Enter the car name : "
let name=Console.ReadLine()
printf "Enter the manufacturing year : "
let year=int(Console.ReadLine())
let car1={Name=name;ManufacturingYear=year}
let numberOfYears=2018-car1.ManufacturingYear
printfn "The car %s have %i years." car1.Name numberOfYears