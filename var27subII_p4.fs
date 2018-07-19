(*
    A singly linked list stores in field nr of each node an integer number.
If the list stores numbers 1,2,3,4,5, what should be the content of the list 
after the execution of the next C++ program sequence:
     p=prim;
     while(p->urm!=NULL)
     {
         p->urm->nr=p->nr*p->urm->nr;
         p=p->urm;
     }
     
*)

(*
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

let example=
    let l=empty
    addLast 1 l
    addLast 2 l
    addLast 3 l
    addLast 4 l
    addLast 5 l
    l
let fn=first example
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
showList example
printfn ""
*)

type LinkedList<'a>=
    | Empty  
    | LinkedList of 'a*LinkedList<'a>

type Node=
    {
        mutable nr:int
    }

let rec addLast newValue=function
    | Empty -> LinkedList ({nr=newValue},Empty)
    | LinkedList (node,linkedList) -> let linkedList=addLast newValue linkedList 
                                      LinkedList (node,linkedList)
let insertValuesAtEndOfLinkedList (values:int array)=
    let linkedList:LinkedList<Node>=values |> Array.fold (fun newList value -> addLast value newList) Empty
    linkedList
let values=[|1..5|]
let list=insertValuesAtEndOfLinkedList values
let rec showList (l:LinkedList<Node>)=
    match l with
    | Empty -> printfn "End of list"
    | LinkedList (node,linkedList) -> printf "%i-" node.nr  
                                      showList linkedList
                     
let addFirst newValue=function
    | Empty -> LinkedList ({nr=newValue},Empty)
    | LinkedList (node,linkedList) -> let linkedList=LinkedList (node,linkedList)
                                      LinkedList ({nr=newValue},linkedList)
let insertValuesAtFrontOfLinkedList (values:int array)=
    let linkedList:LinkedList<Node>=values |> Array.fold (fun newList value -> addFirst value newList) Empty
    linkedList

let list1=insertValuesAtFrontOfLinkedList values

showList list1

let first l=
    match l with
    | Empty -> {nr=1}
    | LinkedList (node,_) -> node
let nextNode (l:LinkedList<Node>)=
    match l with
    | Empty -> Empty
    | LinkedList (_,linkedList) -> linkedList
let modifyList (l:LinkedList<Node>)=
    let prim=first l
    let next=nextNode l
    let rec newLst (p:Node) nx=
        match nx with
        | Empty -> ()
        | LinkedList (node,linkedList) -> node.nr <- p.nr*node.nr
                                          newLst node linkedList
    newLst prim next
modifyList list1
showList list1