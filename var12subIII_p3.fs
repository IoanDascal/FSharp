(*
    Each of files nrVar123I.txt and nrVar123II.txt contains an array of 
    integers in ascending order. Extract from files all numbers that are
    divisible by "div" and appears only in one file.
    Example: If nrVar123I.txt contains : 1 2 3 4 7 20 60
    and nrVar123II.txt contains : 3 5 7 8 9 10 12 20 24
    then the result is : 5 10 60 , if div=5
*)
open System.IO
let readFile fileName=
    use input=File.OpenText(fileName)
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray  



let list1=List.ofArray (Array.map (fun x -> int(x)) (readFile "nrVar123I.txt"))
let list2=List.ofArray (Array.map (fun x -> int(x)) (readFile "nrVar123II.txt"))
printf "div="
let div=int32(System.Console.ReadLine())

let mergeLists xs ys=
    let rec loop xs ys=
        seq{
            match xs,ys with
            | [],ys -> yield! ys
            | xs,[] -> yield! xs
            | x::xs,y::ys -> match x<y with 
                             | true -> yield x
                                       yield! loop xs (y::ys)
                             | false -> match x>y with
                                        | true -> yield y
                                                  yield! loop (x::xs) ys
                                        | false -> yield! loop xs ys                  
        }
    loop xs ys |> List.ofSeq

let finalList= mergeLists list1 list2
printfn "%A" finalList
let res=List.choose (fun x -> match x%div with
                              | 0 -> Some(x)
                              | _ -> None) finalList
printfn "%A" res