(*
 read a,b,c  ( natural numbers >0)
┌ if a>b then
│    t <- a; a <- b; b <- t
└■
┌ while a≤b do
│ ┌ if c|a then
│ │    write a
│ └■
│   a <- a+1
└■
*)
open System
printf " a="
let a =int(Console.ReadLine())
printf " b="
let b=int(Console.ReadLine())
printf " c="
let c=int(Console.ReadLine())
let ab=if a>b then (b,a) else (a,b)
let rec whileLoop a b c=
    match a<=b with
    | true -> if a%c=0 then printf "%i  " a
              whileLoop (a+1) b c 
    | false -> ()
let res=whileLoop (fst ab) (snd ab) c 
printfn ""