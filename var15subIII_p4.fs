(*
    File nrVar154.txt contains integer numbers with maximum
    six digits. Print the last two odd numbers from the file or,
    print "Not enough numbers" if there are less than two odd
    numbers.
*)
open System.IO
let readFile=
    use input=File.OpenText("nrVar154.txt")
    let inputString=input.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray

let numbers=Array.map (fun x -> int(x)) (readFile)
printfn "%A" numbers
let oddNumbers=Array.choose (fun x -> if x%2=1 then Some x else None) numbers
printfn "%A" oddNumbers
if oddNumbers.Length>=2 then
    printf "The last two odd numbers : %i si %i" oddNumbers.[oddNumbers.Length-2] oddNumbers.[oddNumbers.Length-1]
else
    printfn "Not enough numbers"
