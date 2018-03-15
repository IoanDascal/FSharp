(*
    File nrvar113.txt contains in the first row a value for n.
    In the second row it contains n integer numbers. Write 
    in position i the biggest between the number in position i from file
    and the maximum number from position 0 to i-1.
*)
open System.IO
let readFile=
    use input=File.OpenText("FSharp/nrVar113.txt")
    let inputString=input.ReadToEnd()
    let inputString=inputString.Replace(System.Environment.NewLine," ")
    let inputString=inputString.Split([|' '|])
    inputString

let numbers= Array.map (fun x -> int(x)) readFile
let n=numbers.[0]
(*
         Version 1

printfn "n=%i" n
let mutable maxim=numbers.[1]
for i in 1..n do
    if maxim < numbers.[i] then maxim <- numbers.[i]
                                printf "%i " maxim
                            else printf "%i " maxim
*)
//        Version 2

let rec forLoop i maximum=
    match i<=n with
    | false -> ()
    | true -> match numbers.[i] > maximum with
              | true -> printf "%i " numbers.[i]
                        forLoop (i+1) numbers.[i]
              | false -> printf "%i " maximum 
                         forLoop (i+1) maximum  

forLoop 1 numbers.[1]
