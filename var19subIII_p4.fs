(*
    File nrVar193I.txt contains an array of n integers in increasing 
order and file nrVar193II.txt contains an array of m integers in increasing
order. Write a function to merge the two arrays. The final array must contain 
distinct numbers in increasing order.
*)
open System.IO
let readFile file=
    use input=File.OpenText(file)
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let list1=List.ofArray (Array.map int (readFile "nrVar193I.txt"))
let list2=List.ofArray (Array.map int (readFile "nrVar193II.txt"))
let merge xs ys=
    let rec loop xs ys=
        [
            match xs,ys with
            | [],ys -> yield! ys
            | xs,[] -> yield! xs
            | x::xs,y::ys -> match x<y with
                             | true -> yield x
                                       yield! loop xs (y::ys)
                             | false -> match x>y with
                                        | true -> yield y
                                                  yield! loop (x::xs) ys
                                        | false -> yield x
                                                   yield! loop xs ys
        ]
    loop xs ys
let finalList=merge list1 list2
printfn "%A" finalList