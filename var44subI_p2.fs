(*
 read x  ( natural number) 
 y <- 0 
┌ while x>y do
│    y <- y*10+9-x%10; 
└■
 write y 
*)

printf "x="
let x=int32(System.Console.ReadLine())
let rec whileLoop y=
    match x>y with
    | false -> y
    | true -> whileLoop (y*10+9-x%10)

let y=whileLoop 0
printfn "y=%i" y
