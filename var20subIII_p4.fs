(*
    Given two lists of integer numbers in increasing order write a function
that make a new list with common elements from the previous lists. The elemnets 
from the first list are in file nrVar204I.txt and the elements from the 
second list are in file nrVar204II.txt .
*)
open System.IO 
let readFile fileName=
    use input=File.OpenText(fileName)
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray 
let numbers1=List.ofArray (Array.map int (readFile "../nrVar204I.txt"))
let numbers2=List.ofArray (Array.map int (readFile "../nrVar204II.txt"))
let finalList=List.choose (fun x -> match (List.exists (fun y -> y=x) numbers1) with
                                    | true -> Some(x)
                                    | false -> None) numbers2
printfn "%A" finalList
