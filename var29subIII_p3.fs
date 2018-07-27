(*
    Write a function nrOfMultiples : int -> int -> int -> int that take as arguments three
integers a,b,c and returns the number of multiples of number c that lies in the closed
interval [a..b].
*)

open System
printf "Enter a="
let a=int(Console.ReadLine())
printf "Enter b="
let b=int(Console.ReadLine())
printf "Enter c="
let c=int(Console.ReadLine())
let nrOfMultiples (a:int) (b:int) (c:int)=
    if a%c=0 then (b/c-a/c+1)
        else (b/c-a/c)
printfn "The number of multiples of c in closed interval [a..b] is=%i" (nrOfMultiples a b c)