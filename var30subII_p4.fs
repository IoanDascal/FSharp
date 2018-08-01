(*
    A singly linked list stores in field Nr a natural number, 
and in field Next the address of the next node. Implement the 
next C++ program sequence:
    p=first;
    first=last;
    while(p!=first)
    {
        q=p;
        p=p->Next;
        last->Next=q;
        last=q;
    }
    last->Next=NULL;

Variable first stores the address of first node from list.
Variable last stores the address of last node from list.
    1. Find the value stored in the second node from the initial
list;
    2. Find the number of the node that stores the value funded 
at 1 in the final list.
*)

[<ReferenceEquality>]
type Node=
    {
        Nr:int;
        mutable Next:Node option
    }

let values=[|7;32;15;2;8;6;74|]  
let last=Some {Nr=values.[values.Length-1];Next=None}
let addValues (values:int array) (head:Node option)=
    let rec add i (head:Node option)=
        match i=values.Length-1 with
        | true -> head
        | false -> let head=Some {Nr=values.[i];Next=head}
                   add (i+1) head
    let head=add 0 head
    head
let first=addValues values last

let rec showList (list:Node option) i=
    match i=3*values.Length with
    | true -> printfn "This is a circularly linked list."
    | false -> match list with
               | None -> printfn "   End of list"
               | Some node -> printf "%i  " node.Nr
                              showList node.Next (i+1)
printf "first--->"
showList first 0
printf "last--->"
showList last 0
let rec findValueFromNthNode (list:Node option) n=
    match n=1 with  
    | true -> list.Value.Nr
    | false -> findValueFromNthNode list.Value.Next (n-1)

let valueFromNode2=findValueFromNthNode first 2
printfn "The value stored in node 2 is = %i" valueFromNode2

let modifyList first last=
    let p=first
    printf "p--->"
    showList p 0
    let first=last
    printf "first in mod --->"
    showList first 0
    let rec modify (p:Node option) (last:Node option)=
        printf "p in modify--->"
        showList p 0
        match p<>first with
        | false -> last.Value.Next <- None
                   first
        | true -> last.Value.Next<-p
                  let last = p
                  modify p.Value.Next last
    let f=modify p last
    f
let first1=modifyList first last
printf "first1--->"
showList first1 0
let rec findNrOfNodeWithValue value (list:Node option) nodeNumber=
    match list.Value.Nr=value with
    | true -> nodeNumber
    | false -> findNrOfNodeWithValue value list.Value.Next (nodeNumber+1)

let nodeNumber=findNrOfNodeWithValue valueFromNode2 first1 1
printfn "The number of the node which contains the value %i is %i" valueFromNode2 nodeNumber

