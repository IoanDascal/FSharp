(*
    File nrVar94.txt contains natural numbers. 
Write a function that prints in decreasing order the biggest two 
numbers with three digits that are not in file. If the function 
can't find two numbers then, it shall print 0.
*)
open System.IO
let readFile =
    use input=File.OpenText("nrVar94.txt")
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray 

let numbers=Array.filter (fun x -> x>=100 && x<1000) (Array.map (fun x -> int(x)) readFile)
printfn "%A" numbers
let rec find nrElem elem =
    [
        match nrElem with
        | 2 -> printfn ""
        | _ -> if not (Array.exists (fun x -> x=elem) numbers) then yield elem
                                                                    yield! find (nrElem+1) (elem-1)
                                                              else
                                                                  yield! find nrElem (elem-1)
    ]
let res=find 0 999
if res.Length<2 then printfn "0"
    else 
        printfn "%A" res