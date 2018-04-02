(*
 read x ( natural number, n>0)
┌ while x>0 do
│  read y (natural number)
│┌ if x>y then
││     write x%10
││ else
││     write y%10
│└■
│  x <- y
└■
*)
open System
printf "Enter an integer number x="
let x=int32(Console.ReadLine())

let rec whileLoop x=
    match x with
    | 0 -> ()
    | _ -> printf "Enter an integer number y="
           let y=int32(Console.ReadLine())
           match x>y with
           | true -> printfn "%i" (x%10)
           | false -> printfn "%i" (y%10)
           let x=y
           whileLoop x

let res=whileLoop x