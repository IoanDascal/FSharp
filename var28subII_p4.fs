(*
    A singly linked list stores in field nr of each node an integer number.
If the list stores numbers 1,2,3,4,5, what should be the content of the list 
after the execution of the next C++ program sequence:
     p=prim;
     x=p->nr;
     while(p->urm!=NULL)
     {
         p->nr = p->urm->nr;
         p=p->urm;
     }
     p->nr=x;
    
*)

type LinkedList<'a>=
    | Empty  
    | LinkedList of 'a*LinkedList<'a>

type Node=
    {
        mutable nr:int
    }

let values=[|1..5|]  
let addFirst newValue=function
    | Empty -> LinkedList ({nr=newValue},Empty)
    | LinkedList (node,linkedList) -> let linkedList=LinkedList (node,linkedList)
                                      LinkedList ({nr=newValue},linkedList)
let insertValuesAtFrontOfLinkedList (values:int array)=
    let linkedList:LinkedList<Node>=values |> Array.fold (fun newList value -> addFirst value newList) Empty
    linkedList
let rec showList (l:LinkedList<Node>)=
    match l with
    | Empty -> printfn "  - End of list"
    | LinkedList (node,linkedList) -> printf "%i-" node.nr  
                                      showList linkedList
let list=insertValuesAtFrontOfLinkedList values
showList list
let first l=
    match l with
    | Empty -> {nr=1}
    | LinkedList (node,_) -> node
let prim=first list
let num=prim.nr

let rec modifyList (lst:LinkedList<Node>)=
        match lst with
        | Empty -> ()
        | LinkedList (node,Empty) -> node.nr <- num
        | LinkedList (node,linkedList) -> let p=first linkedList
                                          node.nr <- p.nr
                                          modifyList linkedList
modifyList list
showList list