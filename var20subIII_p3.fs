(*
    Given a list of integer numbers, modify the list so that
 null values would be at the end of the list.
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
let numbers=[for i in 0..n-1 do
                yield (printf "num[%i]=" i
                       int(Console.ReadLine()))]
let nullValues:int list=
    let rec loop (num:int list) lst=
        match num with
        | [] -> lst
        | (x::xs) -> match x with
                     | 0 -> loop xs (List.append lst [x])  
                     | _ -> 
                            loop xs (List.append [x] lst)
    loop numbers []
let res=nullValues
printfn "%A" res