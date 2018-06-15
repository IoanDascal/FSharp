(*
    File nrVar184.txt contains maximum 100000 distinct natural numbers.
Given a number k write a function that prints in what position should be 
number k if the array from the file is sorted in decreasing order.
The function must print "Does not exist" if number k isn't in file.
*)
open System.IO
let readFile=
    use input=File.OpenText "nrVar184.txt"
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray 
let numbers= readFile |> Array.map int
printf "Enter k="
let k=int(System.Console.ReadLine())
let res=match Array.exists (fun x -> x=k) numbers with
        | false -> printfn "Does not exist" 
        | true -> let count=Array.countBy (fun x -> x<k) numbers
                  printfn "%A" count
                  match (fst count.[0]) with
                  | false -> printfn "Position is =%i" (snd count.[0])
                  | true -> printfn "Position is =%i" (snd count.[1])

