open System.Collections.Generic
let stiva=Stack<int>()
for i in 1..7 do
    stiva.Push(i) 
printfn "%A" stiva
printfn "Elementul din varful stivei este %i" (stiva.Peek())
let rec numara nr=
    match stiva.Peek() with 
    | 5 -> nr
    |_ -> stiva.Pop() |> ignore
          numara (nr+1)
let num=numara 0
printfn "S-au eliminat %i elemente" num
printfn "Elementul din varful stivei este %i" (stiva.Peek())
stiva.Pop() |>ignore
printfn "Elementul din varful stivei este %i" (stiva.Peek())
stiva.Pop() |> ignore
printfn "Elementul din varful stivei este %i" (stiva.Peek())