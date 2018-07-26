(*
    A circularly linked list stores in field info of each node an integer number.
If the list stores numbers 7,32,15,2,8,1,7, print the elements of the list three
times.
*)
[<ReferenceEquality>]
type Node=
    {
        Info:int;
        mutable Next:Node option
    }

let values=[|7;32;15;2;8;6;74|]  
let head={Info=values.[values.Length-1];Next=None}
let addValues (values:int array) head=
    let rec add i head=
        match i=values.Length-1 with
        | true -> head
        | false -> let head={Info=values.[i];Next=Some head}
                   add (i+1) head
    let head=add 0 head
    head
let head1=addValues values head
head.Next <- Some head1
let circularlyList=Some head
let printNode (node:Node option)=
    printf "  %i" node.Value.Info
let nextNode (node:Node option)=
    match node.Value.Next with  
    | None -> None
    | Some nxt -> Some nxt
let rec printList prim  i=
    match i=3*values.Length with
    | true -> printfn ""
    | false -> printNode prim
               let prim = nextNode prim
               printList prim (i+1)
printList circularlyList 0
printfn ""  
let rec printList1 prim=
    printNode prim
    let prim = nextNode prim
    match prim=circularlyList with
    | true -> printfn "    End"
    | false -> printList1 prim  
printList1 circularlyList

(*
open System.Reflection
let list=[3;6;1;7;5;8;9]
let lastNode=[list.[list.Length-1]]
let last=lastNode.GetType().GetFields(BindingFlags.NonPublic||| BindingFlags.Instance) |> Array.map (fun field -> field.Name)
let taiField=lastNode.GetType().GetField("tail",BindingFlags.NonPublic ||| BindingFlags.Instance)
taiField.SetValue(lastNode,list)
let cList=list |>List.toSeq |> Seq.take 20 |> Seq.toList
printfn "%A" cList
*)