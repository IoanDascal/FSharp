(*
    File nrVar343.txt contains on the first line a value for an 
integer number n, and on the next n rows n integer numbers. 
Each line can be an arithmetic progression. Calculate all arithmetic
progressions.
*)

open System.IO
let input=File.OpenText("nrVar343.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=(readLine input).[0] |> int
printfn "%i " n
for i in 1..n do
    let progression=Array.map  int (readLine input)
    let commonDifference=progression.[1]-progression.[0]
    let mutable isProgression=true
    for i in 1..n-2 do
        if progression.[i+1]-progression.[i]<>commonDifference then
            isProgression <- false
    if isProgression=true then
        printfn "%A" progression
        let sum=n*(progression.[0]+progression.[n-1])/2
        printfn "The sum is s=%i" sum
        let mean=(progression.[0]+progression.[n-1])/2
        printfn "The mean value is=%i" mean
        let standardDeviation=float(abs commonDifference)*sqrt((float(n)-1.0)*(float(n)+1.0)/12.0)
        printfn "The standard deviation is=%A" standardDeviation
