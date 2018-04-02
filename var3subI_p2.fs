(*
 read z,x  ( natural numbers z,x>0)
┌ while x>0 do
│   read y (natural number)
│ ┌ if z<y-x then
│ │    write x%10
│ │ else
│ │    write y%10
│ └■
│   x <- y
└■
*)
open System
printf "Enter z="
let z=int32(Console.ReadLine())
printf "Enter x="
let x=int32(Console.ReadLine())
let rec whileLoop x=
    match x with
    | 0 -> ()
    | _ -> printf "Enter y="
           let y=int32(Console.ReadLine())
           match z<y-x with
           | true -> printfn "%i" (x%10)
           | false -> printfn "%i" (y%10)
           whileLoop y

let res=whileLoop x