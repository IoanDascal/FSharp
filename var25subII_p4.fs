open System
printf "Dati un sir de caractere:"
let s=System.Console.ReadLine()
let rev:string=String(s.ToCharArray() |> Array.rev)
let res=if s=rev then printfn "Corect" else printfn "Incorect"