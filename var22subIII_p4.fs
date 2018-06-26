(*
    File nrVar224.txt contains on the first line a value for the number nr, 
and on each of the next nr lines a pair a,b of integer numbers. Write a function that
return for each pair a,b the maximum number which is a power of two between a and b.
*)
open System.IO
let input=File.OpenText("C:/Users/Nelu/Desktop/fsvsc/FSharp/nrVar224.txt")
let readLine (streamReader:StreamReader)=
    let line=streamReader.ReadLine()
    let line=line.Replace(System.Environment.NewLine," ")
    let line=line.Split([|' '|])
    line

let rec thePowerOf2 a b power=
    if power<=b then thePowerOf2 a b (power*2)
        else if power/2>=a then (power/2)
            else 0
let nr=((readLine input) |> Array.map int).[0]
for i in 1..nr do
    let ab=(readLine input) |> Array.map int
    let a=ab.[0]
    let b=ab.[1]
    let powerOf2=thePowerOf2 a b 1
    printfn "The biggest number, between %i and %i, that is a power of two is=%i " a b powerOf2
printfn ""