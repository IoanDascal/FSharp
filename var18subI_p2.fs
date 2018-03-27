(*
read x,y  ( natural numbers) 
┌ if x>y then
│    y <--> x
└■
┌ if x%2=0 then
│    x <- x+1 
└■
┌ while x ≤ y do
│    x < x+2 
│    write ‘*’ 
└■
*)
open System
printf " x="
let x=Console.ReadLine() |> int
printf " y="
let y=int(Console.ReadLine())
let swap (x,y)=(y,x)
let interchange=if x>y then swap (x,y) else (x,y)
let a=if (fst interchange)%2=0 then ((fst interchange)+1 ) else (fst interchange)
let rec whileLoop x y=
    match x<=y with
    | false -> printfn ""
    | true -> printf "*"
              whileLoop (x+2) y

let res=whileLoop a (snd interchange)