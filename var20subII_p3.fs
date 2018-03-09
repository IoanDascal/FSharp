open System
open System.Collections.Generic

let items=new List<int>(10)
for i in 1..9 do  
    items.Add(i)
let printList=items |> Seq.iter (fun x -> printf "%i  " x)
items.Remove(6) |> ignore 
printfn ""
items |> Seq.iter (fun x -> printf "%i  " x)