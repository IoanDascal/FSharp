(*
    File nrVar134.txt contains an array of integers.
    Generate a list that contains only the even digits.
    Example: If the array is : 25 7 38 1030 45127 0 35 60 15
    then the final list must be : 2 8 42 60
*)
open System.IO
let rec removeDigit n c nr p=
    match n with
    | 0 -> nr
    | _ -> match (n%10)=c with
           | true -> removeDigit (n/10) c nr p
           | false -> removeDigit (n/10) c (nr+(n%10)*p) (p*10)

let readFile=
    use input=File.OpenText("nrVar134.txt")
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray 

let rec removeDigits (number:int) (lst:int list)=
    match lst with
    | [] -> number
    | head::tail -> removeDigits (removeDigit number head 0 1) tail
let numbers=Array.map (fun x -> int(x)) (readFile)

let res=Array.choose (fun x -> let x1=removeDigits x [1;3;5;7;9]
                               match x>=x1 && x1>0 with
                               | true -> Some(x1)
                               | false -> None) numbers
printfn "%A" res
let resString=res |> Array.map (fun x -> string(x)) |> String.concat " "
printfn "ress=%s" resString
File.WriteAllText("nrVar134Rez.txt", resString)