(*
    Given a string a write a function that prints only letters and spaces.
*)

open System
let a="Exam - 2009, August."
a |> String.iter (fun x -> if Char.IsLetter x || Char.IsWhiteSpace x then printf "%c" x else printf "")
printfn ""