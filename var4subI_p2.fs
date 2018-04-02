(*
  read a,b ( înteger numbers)
┌ if a<b then
│    a ↔ b
└■
┌ for x <- a,b,-1 do
│ ┌ if x%2≠0 then
│ │     write x,’ ’
│ └■
└■   
*)

open System
printf "a="
let a=int32(Console.ReadLine())
printf "b="
let b=int32(Console.ReadLine())
let x,y=if a<b then b,a else a,b
let rec forLoop x=
    match x>=y with  
    | false -> ()
    | true -> match x%2<>0 with
              | false -> forLoop (x-1) 
              | true -> printf "%i " x
                        forLoop (x-1)

let res=forLoop x
              
