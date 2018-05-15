(*
    Write a function that reads an integer number n and writes 
in file nrvar5.txt the value of n and all it's prefixes.
Example : for n=10305 file nrvar5.txt must contain :
10305 1030 103 10 1
*)
open System.IO
printf "Enter n="
let n=int32(System.Console.ReadLine())
let rec writeInFile (acc:string) (nr:int)=
    match nr with
    | 0 -> acc
    | _ -> writeInFile (acc+" "+nr.ToString()) (nr/10)

let rez=writeInFile "" n
printfn "%s" rez
File.WriteAllText("nrvar5.txt", rez)