(*
    File nr.txt contains integer numbers. 
Write an application that read the numbers from file
and prints only the natural numbers greather than zero
in increasing order.
*)

open System.IO

let readFile=
    use input=File.OpenText("nr.txt")
    let str=input.ReadToEnd()
    let str=str.Replace(System.Environment.NewLine," ")
    let res=str.Split[|' '|]
    res

let inputArray=readFile
let numbers=inputArray.[..inputArray.Length-1] |> Array.map System.Int32.Parse
                                              |> Array.filter (fun x -> x>0)

let nr=Array.length numbers
printfn "%A" nr
if nr=0 then printfn "There are no natural numbers greather than zero"
    else
        let res=Array.sort numbers
        printfn "%A" res