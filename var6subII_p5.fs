(*
    Given a text with many words that contains only small letters,
write a function that transform first letter from every word to upper case.
*)
open System
printf "Enter text : "
let inputString=Console.ReadLine()
let textToUpper (inputString:string)=
    String.mapi (fun i c -> match i with
                            | 0 -> Char.ToUpper(c)
                            | _ ->if Char.IsWhiteSpace(inputString.[i-1]) && Char.IsLetter(c) then 
                                      Char.ToUpper(c) 
                                      else  c) inputString
let res=textToUpper inputString
printfn "%s" res