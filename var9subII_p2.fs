(*
    A singly linked list stores in field info of each node an integer number.
If the list stores numbers 2,3,4,5,6,7,8 what should be printed after the 
execution of the next C++ program sequence:
     p=prim;
     while(p!=NULL && p->urm!=NULL)
     {
         court<<p->info<<" ";
         p->urm=p->urm->urm;
         p=p->urm;
     }
    
*)

type LinkedList<'a>=
    | Empty  
    | LinkedList of 'a*LinkedList<'a>

type Node=
    {
        info:int option
    }

let values=[|2..8|]  
let rec addLast newValue=function
    | Empty -> LinkedList ({info=newValue},Empty)
    | LinkedList (node,linkedList) -> let linkedList=addLast newValue linkedList 
                                      LinkedList (node,linkedList)
let insertValuesAtEndOfLinkedList (values:int array)=
    let linkedList:LinkedList<Node>=values |> Array.fold (fun newList value -> addLast (Some value) newList) Empty
    linkedList
let rec showList (l:LinkedList<Node>)=
    match l with
    | Empty -> printfn "  - End of list"
    | LinkedList (node,linkedList) -> printf "%i-" node.info.Value 
                                      showList linkedList
let list=insertValuesAtEndOfLinkedList values
showList list
let rec printList (lst:LinkedList<Node>)=
        match lst with
        | Empty -> ()
        | LinkedList (node,Empty) -> ()
        | LinkedList (node,linkedList) -> printf "%i " node.info.Value
                                          match linkedList with
                                          | Empty -> ()
                                          | LinkedList (node,Empty) -> ()
                                          | LinkedList (node,linkedList) -> printList linkedList
printList list