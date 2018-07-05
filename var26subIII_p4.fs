(*
    a. Write a function delete : int[] -> int -> int -> int[], to delete 
all numbers between two indices from an array of integer numbers.
    b. File nrVar264.txt contains on the first line a value for n, and on 
the next line an array of n integer numbers from closed interval [-1000..1000].
Write a function that uses function delete to remove elements from the array, 
so that two consecutive numbers must be different.
*)
open System.IO
let input=File.OpenText("../nrVar264.txt")
let readLine (sr:StreamReader)=
    let inputString=sr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=int((readLine input).[0])
let vector=Array.map int (readLine input)
let vectorInit=vector
let delete (arr:int[]) i j=
    let newArray=Array.append arr.[..i] arr.[j..]
    newArray
let test=delete vector 3 6
printfn "%A" test
let rec remove (arr:int[]) n i=
    match i>=n with
    | true -> arr
    | false -> match arr.[i]=arr.[i+1] with
               | false -> remove arr n (i+1)
               | true -> remove (delete arr i (i+2)) (n-1) i

let finalArray= remove vectorInit (n-1) 0
printfn "%A" finalArray