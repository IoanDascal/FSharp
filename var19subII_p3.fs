(*
    Write a function that prints only letters from a string.
*)
open System
let x="bac2009"
printfn "%s" x
let res=String.iter (fun x -> if (Char.IsLetter x) then printf "%c" x) x
printfn ""