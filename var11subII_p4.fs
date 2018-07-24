(*
    A singly linked list stores in field nr of each node a real number.
If the list stores numbers 2.4,3.2,4.7,5.23,6.75,7.12,8.88 calculate the 
sum of the first three elements from the list.
*)

type LinkedList<'a>=
    | Empty  
    | LinkedList of 'a*LinkedList<'a>

type Node=
    {
        nr:float option
    }

let values=[|2.4;3.2;4.7;5.23;6.75;7.12;8.88|]  
let rec addLast newValue=function
    | Empty -> LinkedList ({nr=newValue},Empty)
    | LinkedList (node,linkedList) -> let linkedList=addLast newValue linkedList 
                                      LinkedList (node,linkedList)
let insertValuesAtEndOfLinkedList (values:float array)=
    let linkedList:LinkedList<Node>=values |> Array.fold (fun newList value -> addLast (Some value) newList) Empty
    linkedList
let rec showList (l:LinkedList<Node>)=
    match l with
    | Empty -> printfn "  - End of list"
    | LinkedList (node,linkedList) -> printf "%f-" node.nr.Value 
                                      showList linkedList
let list=insertValuesAtEndOfLinkedList values
showList list

let rec sum3 lst sum nrElem=
    match nrElem=3 with
    | true -> sum
    | false -> match lst with
               | Empty -> sum
               | LinkedList (node,linkedList) -> sum3 linkedList (sum+node.nr.Value) (nrElem+1)
let res=sum3 list 0.0 0
printfn "Sum= %f" res
let values1=[|7.12;8.88|]
let list1=insertValuesAtEndOfLinkedList values1
let res1=sum3 list1 0.0 0
printfn "Sum= %f" res1
