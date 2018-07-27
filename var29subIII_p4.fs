(*
    We say that a vector A can be reduced to vector B if every element 
from vector B is equal with the sum of a sequence of consecutive elements 
from  vector A. If vector A can be reduced to vector B then the program
must print "YES", otherwise it must print "NO".
Example : A  : 7 3 4 1 6 4 6 9 7 1 8 7
               |___| |_| |_____| |___|
                 |    |     |      |
          B :    14   7     26     16
Vector A can be reduced to vector B, so the program should print "YES"
               
*)
open System.IO
let input=File.OpenText("../nrVar294.txt")
let readLine (istr:StreamReader)=
    let inputString=istr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputArray=inputString.Split([|' '|])
    inputArray

let mn=(readLine input) |> Array.map int
let m=mn.[0]
let n=mn.[1]
let A=(readLine input) |> Array.map int
let B=(readLine input) |> Array.map int
let mutable j=0
let reduceA=[|for i in 0..n-1 do
                yield(let rec sum j k=
                          match Array.sum A.[j..j+k]<B.[i] with
                          | true -> sum j (k+1)
                          | false -> k
                      let k1=sum j 0
                      j <- j+k1+1
                      if Array.sum A.[(j-k1-1)..(j-1)]=B.[i] then Some B.[i]
                          else
                              None)|]
let yesOrNo=Array.forall (fun x -> x<>None) reduceA
if yesOrNo then printfn "YES"
    else printfn "NO"