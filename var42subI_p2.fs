(*
 read x,y ( natural numbers)
┌ while y>0 do
│    z <- x%y 
│    x <- 2*y 
│    y <- 2*z 
└■
 write x 
*)

open System
printf "x="
let x=int32(Console.ReadLine())
printf "y="
let y=int32(Console.ReadLine())
let rec whileLoop x y z=
    match y>0 with
    | false -> x
    | true -> let z=x%y
              let x=2*y
              let y=2*z
              whileLoop x y z

let res=whileLoop x y 0
printfn "%i" res

