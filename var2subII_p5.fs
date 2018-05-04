(*
    Replace every vowel in a word.
*)

printf "Enter a word : "
let word=System.Console.ReadLine()
let replaceA (x:string) (ch:string)=x.Replace(ch,ch+ch.ToUpper())
let replaceE (x:string)=x.Replace("e","eE")
let replaceI (x:string)=x.Replace("i","iI")
let replaceO (x:string)=x.Replace("o","oO")
let replaceU (x:string)=x.Replace("u","uU")
let wordA=replaceA word "a"
let newWord=
    wordA
    |> replaceE
    |> replaceI
    |> replaceO
    |> replaceU

printfn "%s" newWord