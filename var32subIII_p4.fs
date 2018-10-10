(*
    File nrVar324.txt contains an array of Int32 values.
Write a program that print the lowest two numbers with two
digits from the file. If there aren't at least two numbers
with two digits the program should print 0.
*)
open System.IO
let input=File.OpenText("C:/Users/Nelu/Desktop/fsvsc/FSharp/nrVar324.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray

let numbers=Array.map int (readLine input)
let numbersWithTwoDigits=Array.filter (fun x -> abs x>=10 && abs x<100) numbers
if numbersWithTwoDigits.Length<2 then printfn "0"
    else
        let minimum=Array.min numbersWithTwoDigits
        let nextMinimum=Array.minBy (fun x -> if x=minimum then System.Int32.MaxValue else x) numbersWithTwoDigits
        printfn "%i  %i" minimum nextMinimum