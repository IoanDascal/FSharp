open System
printf "Dati un text : "
let text=System.Console.ReadLine()
let textUP (inputString:string)=
    String.mapi (fun i c -> match i with
                            | 0 -> Char.ToUpper(c)
                            | _ ->if Char.IsWhiteSpace(inputString.[i-1]) && Char.IsLetter(c) then 
                                      Char.ToUpper(c) 
                                      else  c) inputString
let res=textUP text
printfn "%s" res