(*
  read x,z ( natural numbers)
  y <- 0
┌ repeat
│    y <- y*10+x%10
│    x <- [x/100]
└ until x=0
┌ while y*z>0 and y%10=z%10 do
│    y <- [y/10]
│    z <- [z/10]
└■
┌ if y+z=0 then
│    write 1
│ else
│    write 0
└■
*)
open System
printf "Enter x="
let x=int32(Console.ReadLine())
printf "Enter z="
let z=int32(Console.ReadLine())
let rec repeatLoop y x=
    match x with
    | 0 -> y
    | _ -> repeatLoop (y*10+x%10) (x/100)

let rec whileLoop (y,z)=
    match y*z>0 && y%10=z%10 with
    | false -> (y,z)
    | true -> whileLoop (y/10,z/10)

let writeResult (f,s)=
    match f+s with
    | 0 -> printfn "1"
    | _ -> printfn "0"

let y=repeatLoop 0 x
printfn "y=%i" y
let res=whileLoop (y, z)
printfn "y=%i" (fst res)
printfn "z=%i" (snd res)
let final=writeResult res 