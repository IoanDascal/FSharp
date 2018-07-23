(*
    Given a list of integer numbers. Write a program to delete
the last element from the list.
*)
///   Method 1
open System.Collections.Generic
let items=new List<int>()
let printList (l:List<_>)=
    printfn "l.Count=%i, l.Capacity=%i" l.Count l.Capacity    
    printfn "Items:"
    l |> Seq.iteri (fun index item -> printfn "      l.[%i]= %i" index l.[index])
    printfn "--------------------------"

items.Add(1)
items.Add(2)
items.Add(3)
items.Add(4)
items.Add(5)
printList items

items.RemoveAt(items.Count-1)
printList items

///   Method 2
let items1=[1..5]
let rec removeLast acc l=
    match l with
    | [] -> acc
    | hd::tail -> match tail with
                  | [] -> acc
                  | _ -> removeLast (acc@[hd]) tail

let res=removeLast [] items1
printfn "%A" res