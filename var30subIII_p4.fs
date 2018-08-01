(*
    File nrVar304.txt contains on the first line a value for an integer number n,
and on the second line n real numbers in increasing order. Calculate the minimum 
number of intervals that can contain all real numbers.
Example: If the file nrVar304.txt contains :
       6
       2.3 2.3 2.8 5.7 5.8 6.3
then the minimum number of intervals is 3. The intervals are: [2,3],[5,6],[6,7].
*)
open System.IO
let input=File.OpenText("../nrVar304.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=(readLine input).[0] |> int
let numbers=(readLine input) |> Array.map float
let x=Array.map int numbers
let endPointsOfIntervals=Array.distinct x
let numberOfIntervals=endPointsOfIntervals.Length
printfn "The minimum number of intervals is %i" numberOfIntervals