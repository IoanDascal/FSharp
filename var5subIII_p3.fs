open System.IO
open System.Net
printf "Dati n="
let n=int32(System.Console.ReadLine())
let rec scrie (acc:string) (nr:int)=
    match nr with
    | 0 -> acc
    | _ -> scrie (acc+" "+nr.ToString()) (nr/10)

let rez=scrie "" n
printfn "%s" rez
File.WriteAllText("nrvar5.txt", rez)