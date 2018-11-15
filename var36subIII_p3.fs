(*
    File nrVar363.txt contains on the first line a value for an integer 
n, and on the next line n integer numbers. Print the biggest number that 
can be obtained with the last even digit from each number. If there is 
no number with even digits then print  "There aren't even digits." 
*)

open System.IO
let input=File.OpenText("nrVar363.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=(readLine input).[0] |> int
let numbers=(readLine input) |> Array.map int

let lastEvenDigit n=
    match n=0 with
    | true -> 0
    | false -> let rec loop n=
                    match n=0 with
                    | true -> -1
                    | false -> match n%2=0 with
                               | true -> n%10
                               | false -> loop (n/10)
               loop n

let frequencies=Array.zeroCreate<int> 11
let computeFrequencies numbers=
    for number in numbers do
        let digit=lastEvenDigit number
        if digit>=0 then frequencies.[digit] <- frequencies.[digit]+1
let res=computeFrequencies numbers
printfn "%A" frequencies

if (Array.exists (fun elem -> elem>0) frequencies)=true then
    for i in 8.. -2 ..0 do
        for j in 1..frequencies.[i] do 
            printf "%i" i  
    printfn ""
else
    printfn "There aren't even digits."