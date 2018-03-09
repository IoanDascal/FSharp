open System.Collections.Generic
let stiva=new Stack<int>()
stiva.Push(1)
stiva.Push(2)
stiva.Push(3)
stiva.Push(4)
stiva.Pop() |> ignore
stiva.Push(5)
stiva.Pop() |> ignore
stiva.Push(6)
stiva.Pop() |> ignore
stiva.Pop() |> ignore
printfn "%A" stiva
printfn "varful stivei=%i" (stiva.Peek())
let nr_elem=stiva.Count
printfn "stiva are %i elemente" nr_elem
let rec suma acc nr_elem=
   match nr_elem with
   | 0 -> acc
   | _ -> suma (acc+stiva.Pop()) (nr_elem-1)

let total=suma 0 nr_elem
printfn "Suma=%i" total