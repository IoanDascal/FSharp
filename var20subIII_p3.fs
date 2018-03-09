open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let numere=[for i in 0..n-1 do
                yield (printf "num[%i]=" i
                       int(System.Console.ReadLine()))]
let lista=[]
let nule:int list=
    let rec loop (num:int list) lst=
        match num with
        | [] -> lst
        | (x::xs) -> match x with
                     | 0 -> loop xs (List.append lst [x])  
                     | _ -> 
                            loop xs (List.append [x] lst)
    loop numere lista
let res=nule
printfn "%A" res