(*
 read x,y  ( natural numbers)
 x <- x%10
 y <- y%10
┌ if y<x then
│    aux <- y
│    y <- x
│    x <- aux
└■
┌ while x≤y do
│    write x*10+y
│    x <- x+1
│    y <- y-1
└■
*)

open System
printf "x="
let x=int32(Console.ReadLine())
printf "y="
let y=int32(Console.ReadLine())
let x1=x%10
let y1=y%10
let xy=if y1<x1 then (y1,x1) else (x1,y1)
let rec whileLoop xy=
    match fst xy<snd xy with
    | false -> ()
    | true -> printfn "%i" ((fst xy)*10+(snd xy))
              whileLoop ((fst xy)+1,(snd xy)-1)

let res=whileLoop xy