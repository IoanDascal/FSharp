(*
    File nrVar104.txt contains many lines with integer numbers.
    In each line the first number represent the code of a product, 
    the second number represents the number of units sold and the third
    number represents the unit price for the product.
    Extract in a dictionary the product code and the total value 
    obtained from selling each product.
    Example: if the file nrVar104.txt contains
      3 1 5
      1 20 5
      2 10 3
      1 10 5
    then the dictionary will contain:
      1 150  
      2 30 
      3 5 
*)

open System.IO
open System.Collections.Generic
let map=new Dictionary<int,int>()
let stream=new StreamReader("FSharp/nrVar104.txt")
let rec readLineFromFile (stream:StreamReader)=
    let line=stream.ReadLine()
    match line with
    | null -> map
    | _ ->  let line=line.Replace(System.Environment.NewLine," ")
            let line=line.Split([|' '|])
            let vect=Array.map (fun x -> int(x)) line
            match map.ContainsKey(vect.[0]) with
                   | false -> map.Add(vect.[0],(vect.[1]*vect.[2]))
                              readLineFromFile stream 
                   | true -> map.[vect.[0]] <- map.[vect.[0]]+vect.[1]*vect.[2] 
                             readLineFromFile stream 
let res=readLineFromFile stream
printfn "%A" res
