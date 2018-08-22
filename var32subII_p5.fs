(*
    Given a text and two characters, c1 and c2, write a program 
to replace every c1 with c2, and every c2 with c1.
*)
open System
printf "Enter a character c1="
let c1=char(Console.ReadLine())
printf "Enter a character c2="
let c2=char(Console.ReadLine())
printf "Enter a text : "
let text=Console.ReadLine()
let res=String.map (fun x -> if x=c1 then c2
                                 else if x=c2 then c1
                                          else x) text
printfn "%s" res