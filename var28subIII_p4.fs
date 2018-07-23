(*
    a. Write a function lowestDivisor : int -> int that returns
the lowest prime divisor af a natural number.
    b. File nrVar284.txt contains on the first line a value for n,
and on the second line an array of n natural numbers. Using function 
lowestDivisor : int -> int write a function to calculate the biggest 
2-almost prime number from the array. If the array doesn't contain a
2-almost prime numbers, the program will print the message:
"There isn't a 2-almost prime number"
*)
open System.IO
let input=File.OpenText("C:/Users/Nelu/Desktop/fsvsc/FSharp/nrVar284.txt")
let readLine (inputReader:StreamReader)=
    let inputString=inputReader.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let lowestDivisor (x:uint32)=
    let rec loop (i:uint32)=
        match x%i=0u with
        | true -> i
        | false -> loop (i+1u)
    loop 2u
let n=(readLine input).[0] |> uint32
let numbers=Array.map uint32 (readLine input)
let almostPrimes=Array.choose (fun x -> let div=lowestDivisor x
                                        let div1=lowestDivisor (x/div)
                                        if x=div*div1 then Some x
                                            else None) numbers
let maximum=Array.max almostPrimes
if maximum>0u then printfn "The biggest number 2-almost prime is =%i" maximum
    else printfn "There isn't a 2-almost prime number."