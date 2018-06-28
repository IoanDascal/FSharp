(*
    File nrVar234.txt contains on the first line a value for a natural number n,
and on each of the next n lines two numbers a,b that are endpoints for a closed
interval [a..b].
    Write a program to print all intervals that do not intersect with other intervals.
*)
open System.IO
let input=File.OpenText("C:/Users/Nelu/Desktop/fsvsc/FSharp/nrVar234.txt")
let readLine (stream:StreamReader)=
    let inputString=stream.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let intersection (a:int,b:int) (c:int,d:int )=
    if c>b || d<a then None
        else Some(a,b)
let test =intersection (3,7) (8,11)
let n=int((readLine input).[0])
let intervalsList=[for i in 1..n do
                        let ab=readLine input
                        let a=int(ab.[0])
                        let b=int(ab.[1])
                        yield (a,b)]
                        
printfn "%A" intervalsList
let res=[for i in 0..n-1 do
             yield((List.choose (fun x -> (intersection x (fst intervalsList.[i],snd intervalsList.[i])))  intervalsList) |>List.length)]
List.iteri (fun i x -> if x=1 then printfn "%A" intervalsList.[i]) res 