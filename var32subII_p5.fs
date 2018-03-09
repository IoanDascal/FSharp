open System
printf "Dati un caracter c1="
let c1=char(System.Console.ReadLine())
printf "Dati un caracter c2="
let c2=char(System.Console.ReadLine())
printf "Dati un text : "
let text=System.Console.ReadLine()
let res=String.map (fun x -> if x=c1 then c2
                                 else if x=c2 then c1
                                          else x) text
printfn "%s" res