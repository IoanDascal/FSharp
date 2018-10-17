(*
    File nrVar334.txt contains on the first line a value for an integer number n,
and on each of the next n lines n integer numbers. 
    -Calculate the biggest number with three digits x from the file;
    -Calculate a number y for which the value of expression |x-y| is minimal.
*)
open System.IO
let input=File.OpenText("nrVar334.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=(readLine input).[0] |> int
printfn "n=%d" n
let rec findXY max3Digits secondMax3Digits min4Digits n=
    match n>1 with
    | false -> (max3Digits,secondMax3Digits,min4Digits)
    | true -> let line=Array.map int (readLine input)
              printfn "%A" line
              let max3DigitsLine=Array.filter (fun x -> x <1000 && x>max3Digits) line
              let max3=match max3DigitsLine with
                       | [||] -> max3Digits
                       | arr -> Array.max arr
              let secondMax3=if max3>max3Digits then max3Digits else secondMax3Digits
              let min4DigitsLine=Array.filter (fun x -> x >=1000 && x<min4Digits) line             
              let min4=if (Array.isEmpty min4DigitsLine) then min4Digits else (Array.min min4DigitsLine)
              findXY max3 secondMax3 min4 (n-1)

let x,y1,y2=findXY 0 0 10000 n
if abs(x-y1)<=abs(x-y2) then printfn "%d  %d" x y1
    else 
        printfn "%d  %d" x y2