(*
    A singly linked list stores in field info of each node an integer number.
If the list stores numbers 7,3,15,2,8,1, calculate the sum of all elements 
from the list. 
*)

type LinkedList<'a>=
    | Empty  
    | LinkedList of 'a*LinkedList<'a>

type Node=
    {
        mutable info:int option
    }

let values=[|7;3;15;2;8;1|]  
let addFirst newValue=function
    | Empty -> LinkedList ({info=newValue},Empty)
    | LinkedList (node,linkedList) -> let linkedList=LinkedList (node,linkedList)
                                      LinkedList ({info=newValue},linkedList)
let insertValuesAtFrontOfLinkedList (values:int array)=
    let linkedList:LinkedList<Node>=values |> Array.fold (fun newList value -> addFirst (Some value) newList) Empty
    linkedList
let rec showList (l:LinkedList<Node>)=
    match l with
    | Empty -> printfn "  - End of list"
    | LinkedList (node,linkedList) -> printf "%i-" node.info.Value  
                                      showList linkedList
let list=insertValuesAtFrontOfLinkedList values
showList list

let rec sumList (lst:LinkedList<Node>) s=
        match lst with
        | Empty -> s
        | LinkedList (node,linkedList) -> sumList linkedList  (s+node.info.Value)
let sum=sumList list 0
printfn "The sum of the elements from the list is =%i" sum