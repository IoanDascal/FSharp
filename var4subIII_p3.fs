(*
    File nrVar4.txt contains integer numbers. Write a 
function that prints in descending order all the numbers
with maximum 2 digits, separated by a space.
*)

open System.IO
let readFile=
    use input=File.OpenText("nrVar4.txt")
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray

let stringArray=readFile
let numbers=stringArray.[..stringArray.Length-1] 
            |> Array.map (fun x -> int32(x)) 
            |> Array.filter (fun x -> x<100)

if numbers.Length=0 then printfn "There are no numbers less than 100"
    else
        let res= Array.sortDescending numbers
        printfn "%A" res