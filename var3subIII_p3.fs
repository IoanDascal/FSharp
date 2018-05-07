(*
    File nrVar33.txt contains integer numbers. Write a function that prints 
only numbers with minimum three digits in increasing order. 
*)
open System.IO

let readFile=
    use input=File.OpenText("FSharp/nrVar33.txt")
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
 
let stringArray =readFile
printfn "%A" stringArray
let numbers=stringArray.[..stringArray.Length-1] |> Array.map (fun x -> int32(x))
                                |> Array.filter (fun x -> x>=100 || x<= -100)

let nr=Array.length numbers
if nr=0 then printfn "There are no numbers with minimum 3 digits"
    else
        let res=Array.sort numbers
        printfn "%A" res
        let sum=Array.sum res
        printfn "sum=%d" sum
