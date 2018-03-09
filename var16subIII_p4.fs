open System.IO
let input=
    try
        File.OpenText "nrVar164.txt"
    with
        | :? FileNotFoundException -> printfn "Error: nrVar164.txt not found.";exit(1)
let cifre=Array.zeroCreate<int> 10
let res (linie:string)=
    match linie with
    | null -> false
    | sir -> for i in 0..sir.Length-1 do 
                 cifre.[(int sir.[i])-48] <- cifre.[(int sir.[i])-48]+1
             true

while res (input.ReadLine()) do ()
printfn "%A" cifre 
for i in 9.. -1..0 do
    for j in 0..cifre.[i]-1 do
        printf "%i" i
printfn ""