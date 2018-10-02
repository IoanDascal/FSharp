(*
    Given a doubly linked list, insert, after each node that contains 
a negative number, a new node which contains value 0. 

    https://rosettacode.org/wiki/Doubly-linked_list/Definition#F.23
*)

type DoublyLinkedListNode<'a>=
    {
        data:'a;
        mutable prev: DoublyLinkedListNode<'a> option;
        mutable next: DoublyLinkedListNode<'a> option
    }
type DoublyLinkedList<'a>=
    {
        mutable front:DoublyLinkedListNode<'a> option;
        mutable back: DoublyLinkedListNode<'a> option
    }

let empty()={front=None;back=None}
let addFront doublyLinkedList element=
    match doublyLinkedList.front with
    | None -> let firstNode=Some {prev=None; data=element; next=None}
              doublyLinkedList.front <- firstNode
              doublyLinkedList.back <- firstNode
    | Some node -> let newNode=Some {prev=None;data=element;next=Some node}
                   node.prev <- newNode
                   doublyLinkedList.front <- newNode
let addBack doublyLinkedList element=
    match doublyLinkedList.back with
    | None -> addFront doublyLinkedList element 
    | Some node -> let newNode=Some {prev=Some node; data=element; next=None}
                   node.next <- newNode
                   doublyLinkedList.back <- newNode
let DLList=empty()
addFront DLList 7
addFront DLList 8
addFront DLList -9
addBack DLList 10
addFront DLList 11
addFront DLList 13
addBack DLList -10
addBack DLList 15
addBack DLList 19
printfn "%A" DLList
let printDoublyLinkedList doublyLinkedList=
    let frontNode=doublyLinkedList.front 
    let rec print frontNode=
        match frontNode with
        | None -> printfn "   End of List!"
        | Some node -> printf " %A " node.data
                       print node.next
    print frontNode
printfn "----------------------------------------------------------------"
printDoublyLinkedList DLList
let addAfterNegativeElement doublyLinkedList=
    let frontNode=doublyLinkedList.front
    let rec addAfter frontNode=
        match frontNode with
        | None -> doublyLinkedList
        | Some node -> match node.data<0 with
                       | false -> addAfter node.next
                       | true -> if node.next=doublyLinkedList.back then addBack doublyLinkedList 0 
                                                                         doublyLinkedList    
                                     else   
                                         let newNode=Some {prev=Some node; data=0; next=node.next}
                                         node.next <- newNode
                                         addAfter node.next
    addAfter frontNode

let finalList=addAfterNegativeElement DLList
printDoublyLinkedList finalList