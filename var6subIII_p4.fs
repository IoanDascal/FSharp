(*
    File nrVar64.txt contains an array of numbers in increasing order.
Write a function that print distinct numbers with their frequencies.
*)
open System.IO
let readFile=
    use input=File.OpenText("nrVar64.txt")
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray 
let stringArray=readFile
printfn "%A" stringArray
let numbers= Array.map (fun x -> int(x)) stringArray
printfn "Input array : %A" numbers
//       Version 1
let mutable frequency=1
let differentNumbers=List.append [for i in 0..numbers.Length-2 do
                                      if numbers.[i]<> numbers.[i+1] then yield (numbers.[i],frequency);frequency <- 1
                                       else frequency <- frequency+1  ] [(numbers.[numbers.Length-1],frequency)]
printfn "Different numbers : %A" differentNumbers
 
 //   Version 2
let distinctNumbers=
    Seq.ofArray numbers
    |> Seq.distinct
    |> Seq.toArray
     
printfn "Distinct Numbers : %A" distinctNumbers
let count value aray=
    Seq.where (fun x -> x=value) aray
    |> Seq.length

let frequencies=[|for i in 0..distinctNumbers.Length-1 do
                    yield count distinctNumbers.[i] numbers|]
printfn "Frequencies : %A" frequencies
let result=[|for i in 0..distinctNumbers.Length-1 do yield (distinctNumbers.[i],frequencies.[i])|]
printfn "Different numbers : %A" result