(*
    File nrVar84.txt contains on the first line values for n and m, 
on the second line an array of n natural even numbers in increasing
order and on the third line an array of m odd natural numbers in increasing order.
Write a function that merge the two arrays. Consecutive numbers must be 
of different parities.
*)
open System.IO
let input=File.OpenText("nrVar84.txt")
let readLine (input:StreamReader)=
    let inputString=input.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray 

let nm=readLine input
let n=int32(nm.[0])
printfn "n=%i" n 
let m=int32(nm.[1])
printfn "m=%i" m 
let a=List.ofArray (Array.map (fun x -> int32(x)) (readLine input))
let b=List.ofArray (Array.map (fun x -> int32(x)) (readLine input))
printfn "a= %A" a

printfn "b= %A" b
let merge ant xs ys=
    let rec loop ant xs ys=
        seq{
            match xs,ys with
            | [],ys -> yield! ys
            | xs,[] -> yield! xs
            | x::xs,y::ys -> match x<y with
                             | true ->  match ant with
                                        | -1 -> yield x
                                                yield! loop x xs (y::ys)
                                        | _ -> match ant%2=x%2 with
                                               | true -> yield! loop x xs (y::ys)
                                               | false -> yield x
                                                          yield! loop x xs (y::ys)
                             | false -> match ant with
                                        | -1 -> yield y 
                                                yield! loop y (x::xs) ys
                                        | _ -> match ant%2=y%2 with
                                               | true -> yield! loop y (x::xs) ys
                                               | false -> yield y
                                                          yield! loop y (x::xs) ys 
        }
    loop ant xs ys |> List.ofSeq

let final=merge -1 a b
printfn "%A" final