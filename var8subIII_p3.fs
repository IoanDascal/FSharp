(*
    File nrVar83.txt contains on the first line a value for number n
and on the second line n natural numbers with maximium four digits. 
Print the sum of numbers that are perfect squares.
*)
open System.IO
let input=File.OpenText("nrVar83.txt")
let readLine (input:StreamReader)=
    let inputString=input.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray

let isPerfectSquare (x:uint32)=
    let y=uint32(round (sqrt (float x)))
    y*y=x 
let line1=readLine input
let n=uint32(line1.[0])
let line2=(Array.map (fun x -> uint32(x)) (readLine input)) |> Array.choose (fun x -> match (isPerfectSquare x) with 
                                                                                      | false -> None 
                                                                                      | true -> Some(x)) 
for i in 0..line2.Length-2 do printf "%i + " line2.[i]
printf "%i = %i" line2.[line2.Length-1] (Array.sum line2)
printfn ""
