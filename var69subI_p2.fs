(*
 read x,y  ( natural numbers >0)
 t <- 0
 u <- 1
┌ repeat
│┌ if x%10 > y%10 then
││    z <- x%10
││ else
││    z <- y%10
│└■
│  t <- t+z*u
│  u <- u*10
│  x <- [x/10]
│  y <- [y/10]
└ until x=0 and y=0
 write t 
*)

open System
printf "x="
let x=int32(Console.ReadLine())
printf "y="
let y=int32(Console.ReadLine())
let rec repeatLoop x y t u=
    let z=if x%10>y%10 then x%10 else y%10
    let t=t+z*u
    let x=x/10
    let y=y/10
    match x=0 && y=0 with
    | true -> t
    |false -> repeatLoop x y t (u*10)

let t=repeatLoop x y 0 1
printfn "t=%i" t 
