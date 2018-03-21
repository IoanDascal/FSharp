(*
    File nrVar164.txt contains on each line a natural number
    with maximum nine digits. Print in decreasing order all digits
    from all numbers.
*)
open System.IO
let input=
    try
        File.OpenText "nrVar164.txt"
    with
        | :? FileNotFoundException -> printfn "Error: nrVar164.txt not found.";exit(1)
let digits=Array.zeroCreate<int> 10
let readLine (line:string)=
    match line with
    | null -> false
    | sir -> for i in 0..sir.Length-1 do 
                 digits.[(int sir.[i])-48] <- digits.[(int sir.[i])-48]+1
             true

while readLine (input.ReadLine()) do ()
printfn "%A" digits 
for i in 9.. -1..0 do
    for j in 0..digits.[i]-1 do
        printf "%i" i
printfn ""