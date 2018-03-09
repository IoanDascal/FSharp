open System
let x="bac2009"
printfn "%s" x
let res=String.iter (fun x -> if (System.Char.IsLetter x) then printf "%c" x) x
printfn ""