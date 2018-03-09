open System
let cuvant=System.Console.ReadLine()
let replaceA (x:string) (ch:string)=x.Replace(ch,ch+ch.ToUpper())
let replaceE (x:string)=x.Replace("e","eE")
let replaceI (x:string)=x.Replace("i","iI")
let replaceO (x:string)=x.Replace("o","oO")
let replaceU (x:string)=x.Replace("u","uU")
let cuvantA=replaceA cuvant "a"
let cuvantNou=
    cuvantA
    |> replaceE
    |> replaceI
    |> replaceO
    |> replaceU

printfn "%s" cuvantNou