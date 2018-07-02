(*
    File nrVar244.txt contains on the first line a value for an
integer number n, on the next n lines it contains integer numbers
in increasing order, and on the last line values for integer 
numbers a and b.
    Write a function to find the lowest number from the closed
interval [a..b]. If there is no number, the function should print "NO"
*)
open System.IO
let input=File.OpenText("C:/Users/Nelu/Desktop/fsvsc/FSharp/nrVar244.txt")
let readLine (istr:StreamReader)=
    let inputString=istr.ReadLine()
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=(Array.map int (readLine input)).[0]
let vector=[|for i in 1..n do
                 yield((Array.map int (readLine input)).[0])|]
let ab=Array.map int (readLine input)
let first=Array.tryFind (fun x -> x>=ab.[0] && x<=ab.[1]) vector
if first.IsSome then
    printfn "%i" first.Value
    else   
       printfn "NO"