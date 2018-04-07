(*
 read x,y  ( natural numbers)
┌ while x*y≠0 do
│┌ if x>y then
││    x <- x%y 
││ else 
││    y <- y%x 
│└■
└■
 write x+y 
*)

open System
printf "x="
let x=int32(Console.ReadLine())
printf "y="
let y=int32(Console.ReadLine())
let rec whileLoop x y=
    match x*y<>0 with
    | false -> x+y
    | true -> match x>y with
              | true -> whileLoop (x%y) y
              | false -> whileLoop x (y%x)

let xy=whileLoop x y
printfn "x+y=%i" xy
