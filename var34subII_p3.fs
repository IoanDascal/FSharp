(*
    In a singly linked list are stored next values: 
    2 -> 3 -> 4 -> 7 -> 5 -> 9 -> 14
Variable p stores the address of the first node in the list.
What is the value stored in field info of p after the execution 
of the next C++ program:
    p=p->urm;
    while(p->urm->urm!=0)
        p=p->urm->urm;
*)

type LinkedList<'a>=
    | Empty
    | LinkedList of 'a*LinkedList<'a>
type Node=
    {
        info:int option
    }
let values=[14;9;5;7;4;3;2]
let addFirst newValue=function
    | Empty -> LinkedList ({info=newValue},Empty)
    | LinkedList (node,linkedList) -> let linkedList=LinkedList (node,linkedList)
                                      LinkedList ({info=newValue},linkedList)
let insertValuesAtFrontOfList (values:int list)=
    let linkedList:LinkedList<Node>=values |> List.fold (fun newList value -> addFirst (Some value) newList) Empty
    linkedList
let rec showList (li:LinkedList<Node>)=
    match li with
    | Empty -> printfn "      End of list"
    | LinkedList (node,linkedList) -> printf "%i-" node.info.Value
                                      showList linkedList
let list=insertValuesAtFrontOfList values
showList list
let nextNode lst=
    match lst with
    | Empty -> Empty
    | LinkedList (node,Empty) -> Empty
    | LinkedList (node,linkedList) -> linkedList
let secondNode lst=
    let nxtNode=nextNode lst
    match nxtNode with
    | Empty -> Empty
    | LinkedList (node,Empty) -> Empty
    | LinkedList (node,linkedList) -> linkedList
let extractNodeValue li=
    match li with
    | Empty -> None
    | LinkedList (node,_) -> node.info
let lt=nextNode list
let v=extractNodeValue lt
printfn "%d" v.Value

let rec parseList lst=
    match lst with
    | Empty -> Empty
    | LinkedList (node,Empty) -> LinkedList (node,Empty)
    | LinkedList (node,linkedList) -> let lst2=secondNode linkedList
                                      match lst2 with
                                      | Empty -> linkedList
                                      | LinkedList (node,Empty) -> LinkedList (node,Empty)
                                      | LinkedList (node,linkedList) -> parseList lst2
let final=parseList lt
let finalVal=extractNodeValue final
printfn "%d" finalVal.Value
