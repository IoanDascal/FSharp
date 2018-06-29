(*
    Given two strings print their longest common suffix.
*)

open System
printf "Enter first string : "
let string1=Console.ReadLine()
printf "Enter second string : "
let  string2=Console.ReadLine()
let n=string1.Length
let m=string2.Length
let mutable i=1
while string1.[n-i]=string2.[m-i] do i <- i+1
printfn "%i" i
if i=1 then printfn "There is no common suffix"
    else
        printfn "The common suffix of the two strings is : %s" string1.[(n-i+1)..]
