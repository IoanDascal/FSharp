(*
    Given an array of n integers. At what index should be the
    first item in the sorted array.
*)
open System.IO
let input=try
             File.OpenText "nrVar174.txt"
          with
              | :? FileNotFoundException -> printfn "Error: File nrVar174.txt not found";exit(1)

let readFile=
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray 

let numbers=readFile |> Array.map int
let positions=Array.countBy (fun x -> x<numbers.[0]) numbers
let res=
    match fst positions.[0] with
    | true -> printfn "%i" (snd positions.[0])
    | false -> printfn "%i" (numbers.Length-(snd positions.[0]))

res 