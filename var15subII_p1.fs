(*
    A singly linked list stores in field info of each node an integer number.
If the list stores numbers 7,32,15,2,8,1,7, what should be printed after the 
execution of the next C++ program sequence:
    p=prim;
    while ((p->inf%2==0) && (p!=NULL))
        p=p->ref;
    if (p!=NULL)
        cout<<(p->inf); | printf("%d",p->inf);
    else
        cout<<"No";
*)

type LinkedList<'a>=
    | Empty  
    | LinkedList of 'a*LinkedList<'a>

type Node=
    {
        mutable info:int option
    }

let values=[|7;32;15;2;8;6;74|]  
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

let rec skipNodes lst=
    match lst with
    | Empty -> Empty
    | LinkedList (node,linkedList) -> if node.info.Value%2<>0 then LinkedList (node,linkedList )
                                          else 
                                              skipNodes linkedList  
let list1=skipNodes list
let printFirstNode lst=
    match lst with
    | Empty -> printfn "No"
    | LinkedList (node,linkedList) -> printfn "%i" node.info.Value
printFirstNode list1
