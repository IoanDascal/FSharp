(*

*)
//(*
type Node=
    {
        mutable nr:int;
        next:List
    }
and List=Node option ref

let empty:List=ref None
let singleton x=
    {
        nr=x;
        next=ref None
    }
let rec addLast x l=
    match !l with
    | None -> l:=Some (singleton x) 
    | Some node -> addLast x node.next
let newNode x (l:List)=
    {
        nr=x;
        next=l
    }
let addFirst x l=
    if l=empty then  l:=Some {nr=x;next=ref None}
        else let node={nr=x;next=ref None} 
             node.next:=!l
             l:=Some node
                                     
let  first (list:List)=
    match !list with
    | None -> None
    | Some node -> Some node
let nextNode (node:Node option)=
    match node with
    | None -> empty
    | Some node -> node.next
let showNode (node:Node option)=
    if node.IsSome then printf "%i-" node.Value.nr

let example1=
    let l=empty
    addLast 1 l
    addLast 2 l
    addLast 3 l
    addLast 4 l
    addLast 5 l
    l
let fn=first example1
showNode fn
let next=nextNode fn
let fn1=first next
showNode fn1
let rec showList (l:List)=
    let fn=first l
    if fn.IsSome then showNode fn
                      showList (nextNode fn)
                 else printfn "End of list"
printf "Ex1 : "
showList example1
printfn ""

let example2=
    let l1=empty
    addFirst 1 l1
    addFirst 2 l1
    addFirst 3 l1
    addFirst 4 l1
    addFirst 5 l1
    l1
let fnn=first example2
showNode fnn
let nextn=nextNode fnn
let fnn1=first nextn
showNode fnn1
printf "Ex 2 : "
showList example2
printfn ""
//*)
(*
type LinkedList<'a>=
    | Empty  
    | LinkedList of 'a*LinkedList<'a>

let rec addLast newValue=function
    | Empty -> LinkedList (newValue,Empty)
    | LinkedList (nr,linkedList) -> let linkedList=addLast newValue linkedList 
                                    LinkedList (nr,linkedList)
let insertValuesInLinkedList (values:'a array)=
    let linkedList=values |> Array.fold (fun newList value -> addLast value newList) Empty
    linkedList
let values=[|1..5|]
let list=insertValuesInLinkedList values
printfn "%A" list
let addFirst newValue=function
    | Empty -> LinkedList (newValue,Empty)
    | LinkedList (nr,linkedList) -> let linkedList=LinkedList (nr,linkedList)
                                    LinkedList (newValue,linkedList)
let insertValuesInLinkedList1 (values:'a array)=
    let linkedList=values |> Array.fold (fun newList value -> addFirst value newList) Empty
    linkedList

let list1=insertValuesInLinkedList1 values
printfn "%A" list1
*)