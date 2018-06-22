(*
    File nrVar214.txt contains on the first line values for n and k;
where n is the number of elements from an array of integers and k is 
the length of a subarray. The second line from file contains an array 
of n integers. Calculate the starting index of the contiguous subarray 
with k elements within a one-dimensional array of n numbers which has 
the largest sum.
*)
open System.IO
let input=File.OpenText("../nrVar214.txt")
let readLine (streamReader:StreamReader)=
    let inputString=streamReader.ReadLine() 
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray

let nk=readLine input
let n=int(nk.[0])
let k=int(nk.[1])
let numbers=Array.map int (readLine input)
let sumsArray=Array.mapi (fun i x -> if i<=n-k then (Array.sum numbers.[i..(i+k-1)]) else x) numbers
let maximum=Array.max sumsArray
let index=Array.findIndex (fun x -> x=maximum) sumsArray
printfn "The sequence of k=%i numbers with the maximum  sum=%i starts from index=%i" k maximum index
