(*
    Write a programme that print "Correctly" if a string is a
palindrome, otherwise it should print "Incorrectly".
*)
open System
printf "Enter a string :"
let s=Console.ReadLine()
let rev:string=String(s.ToCharArray() |> Array.rev)
let res=if s=rev then printfn "Corecctly" else printfn "Incorrectly"