(*
 read x,y  ( natural numbers)
┌ if x<y then
│     x <- x-y
│     y <- x+y
│     x <-y-x
└■
┌ while x≥y do
│     write ’A’
│     x <- x-y
│     write ’B’
└■
*)
open System
printf " x="
let x=int(Console.ReadLine())
printf " y="
let y=int(Console.ReadLine())
let swap (y,x)=(x,y)
let interchange=if x<y then swap (x,y) else (x,y)
printfn "%i" (fst interchange)
let a=fst interchange
let b=snd interchange
let rec printResult a b=
    match a>=b with
    | false -> printf ""
    | true -> printf "A"
              printResult (a-b) b
              printf "B"

let res = printResult a b