(*
    File test.txt contains an array of integer numbers.
    Write a program that reads the numbers from the file and
    print only the numbers divisible by n.
*)
open System.IO
let readFile=
    use input=File.OpenText("nrVar13.txt")
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray

let array=readFile 
printf " n="
let n=int32(System.Console.ReadLine())
printfn "n=%d" n

let numbers=array.[..(array.Length-1)] |> Array.map System.Int32.Parse
                                       |> Array.filter (fun x -> x%n=0)
if numbers.Length=0 then
    printfn "The file does not contain any number divisible by n"
else
    for number in numbers do
        printf "%i  " number
printfn ""
