let triangleNumbers=
    [1..10] |> Seq.collect (fun i -> [1..i]) |> Seq.toList

//       Print triangleNumbers with for loops
let mutable k=0
for i in 1..10 do
    for j in 1..i do
        printf "%i " (triangleNumbers.Item(k))
        k<-k+1
    printfn ""

//      Print triangleNumbers using recursive functions
let rec forLoop i k=
    printfn ""
    match i>10 with
    | true -> ()
    | false -> let rec innerForLoop j i k=
                   match j<=i with
                   | false -> forLoop (i+1) k
                   | true -> printf "%i " (triangleNumbers.Item(k))
                             innerForLoop (j+1) i (k+1)
               innerForLoop 1 i k

let res=forLoop 1 0
printfn ""