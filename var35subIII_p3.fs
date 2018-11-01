(*
    File nrVar353.txt contains on the first row a value for an integer n,
and on the second row n integer numbers. Write a function that prints all
numbers for which the first digit is equal with the last digit.
*)

open System.IO
let input=File.OpenText("nrVar353.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=(readLine input).[0] |> int
let numbers=readLine input
let printNumbers (num:string array)=
    for i in 0..n-1 do
        if num.[i].[0]=num.[i].[num.[i].Length-1] then
            printf "%s  " num.[i]
printNumbers numbers