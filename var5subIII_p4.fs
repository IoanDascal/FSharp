open System
printf "Dati n="
let n=int32(System.Console.ReadLine())
let rec divizor nr div=
   match nr%div with
   | 0 -> div
   | _ -> divizor nr (div+1)

let test1=divizor n 2
printfn "Divizorul este=%i" test1
let prime=[|for i in 1..n do 
               printf "sir[%i]=" i
               yield int32(System.Console.ReadLine())|] 
           |> Array.filter (fun x -> x=(divizor x 2))
           |> Array.sort

if prime.Length=0 then printfn "Nu exista"
    else
        printf "%A" prime