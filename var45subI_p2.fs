(*
 read x,y  ( natural numbers)
 z <- 1 
 t <- 0 
┌ while x≥z do
│┌ if x%z=y then
││    t <- z 
│└■
│  z <- z+1 
└■
 write t 
*)

open System
printf "x="
let x=int32(Console.ReadLine())
printf "y="
let y=int32(Console.ReadLine())
let rec whileLoop z t=
    match x>=z with
    | false -> t
    | true -> whileLoop (z+1) (if x%z=y then z else t)

let t=whileLoop 1 0
printfn "t=%i" t
