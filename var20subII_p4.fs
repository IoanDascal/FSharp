open System
let a="Bac 2009 iulie"
a |> String.iter (fun x -> if System.Char.IsLetter x || System.Char.IsWhiteSpace x then printf "%c" x else printf "")
printfn ""