(*
    File nrVar274.txt contains on the first line a value for an integer 
number n and on the next line n real numbers in increasing order.
Write a program to calculate the minimum interger numbers that lies
between endpoints of all closed intervals that can be obtained with 
numbers from the second line of the file.
*)
open System.IO
let input=File.OpenText("C:/Users/Nelu/Desktop/fsvsc/FSharp/nrVar274.txt")
let readLine (input:StreamReader)=
    let inputString=input.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=(readLine input).[0] |>int 
let numbers=(readLine input) |>Array.map float
let differences=[for i in 0..n-2 do
                    for j in i+1..n-1 do
                        yield(int(floor(numbers.[j])-floor(numbers.[i])))]
let minimum=List.min differences
printfn "Minimum =%i" minimum