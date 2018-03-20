(*
      |a| is the absolute value of a
      [b] is the integer part of real number b
 read z, x (integer numbers, z<>0 and x<>0 )
 z <- |z|
 x <- |x|
┌repeat
│  y <- x
│  x <- [(x+z/x)/2]
└ until x=y
 write x 
*)

printf "z="
let z=abs(int32(System.Console.ReadLine()))
printf "x="
let x=abs(int32(System.Console.ReadLine()))
let rec repeatLoop x y=
    match x=y with
    | true -> x
    | false -> repeatLoop ((x+z/x)/2) x 

let res=repeatLoop x (x-1)
printfn "%i" res