(*
    A circularly linked list stores in field info of each node an integer number.
If the list stores numbers 1,2,3,4,5,6,7,8,9, write a function to find a value in
the list.
*)
[<ReferenceEquality>]
type Node=
    {
        Info:int;
        mutable Next:Node option
    }

let values=[|1..9|]  
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
let rec printList first=
    printNode first
    let first = nextNode first
    match first=circularlyList with
    | true -> printfn "    End"
    | false -> printList first  
printList circularlyList

let findValue (first:Node option) (value:int)=
    let rec find (fst:Node option)=
        match fst.Value.Info=value with
        | true -> fst
        | false -> let fst=nextNode fst
                   match fst=circularlyList with
                   | true -> None
                   | false -> find fst
    let node=find first
    node

let first=findValue circularlyList 5
let printResult (fst:Node option)=if fst.IsSome then printList fst
                                     else  
                                         printfn "The value is not in list"
let res=printResult first
let first1=findValue circularlyList 15

let res1=printResult first1