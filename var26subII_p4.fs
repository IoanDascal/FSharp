open System.Collections.Generic
let stiva=new Stack<int>()
stiva.Push(40)
stiva.Push(22)
stiva.Push(20)
stiva.Push(18)
stiva.Push(10)
stiva.Push(2)
let InStiva nr=
    while stiva.Peek()<nr do 
        stiva.Pop() |> ignore
    stiva.Push(nr)
let res=InStiva 11
printfn "%A" stiva
let lista=[20;5;16;9;3;7;5;4;8]
let calcul=List.iter (fun x -> (InStiva x)) lista
for el in stiva do
    printf "%i " el