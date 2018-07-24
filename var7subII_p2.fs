(*
    A singly linked list stores in field info of each node an integer number.
If the list stores numbers 7,3,15,2,8,1, what should be the content of the list 
after the execution of the next C++ program sequence:

     while(p->urm!=NULL)
     {
         if(p->urm->info < p->info)
             p->urm->info = p->info;
         p=p->urm;
     }
     cout<<p->info;
    
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
let first l=
    match l with
    | Empty -> {info=None}
    | LinkedList (node,_) -> node

let rec modifyList (lst:LinkedList<Node>)=
        match lst with
        | Empty -> ()
        | LinkedList (node,Empty) -> ()
        | LinkedList (node,linkedList) -> let p=first linkedList
                                          if p.info<node.info then p.info <- node.info
                                          modifyList linkedList
modifyList list
showList list