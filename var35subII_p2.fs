(*
    http://www.fssnip.net/2g/title/LinkedList-extensions
    Given a singly linked list :
a. Test if the liked list contains only numbers divisible by div;
b. If the list contains numbers that are not divisible by div
   find the position of the first of such numbers.

   Try with div=5.
*)

  
open System.Collections.Generic
type Result<'TSuccess,'TFailure>=
    | Success of 'TSuccess
    | Failure of 'TFailure
let empty<'a> = LinkedList<'a>()
let ofSeq<'a> (xs:'a seq) = LinkedList<'a>(xs)

let find (f:'a->bool) (xs:LinkedList<'a>) =    
    let node = ref xs.First
    while !node <> null && not <| f((!node).Value) do 
        node := (!node).Next
    if !node<>null then Success !node   
        else
            Failure (sprintf "%s" "Element not found.")
let findi (f:int->'a->bool) (xs:LinkedList<'a>) =
    let node = ref xs.First
    let i = ref 0
    while !node <> null && not <| f (!i) (!node).Value do 
        incr i; node := (!node).Next
    if !node = null then Failure (sprintf "%s" "Position not found.") 
        else 
            Success !i

let values=Seq.concat [[25..5..95]; [100..10..150]]
let linkedList =new LinkedList<int>(values)
printfn "The linked list is: %A" linkedList
printf "Enter div="
let div=int(System.Console.ReadLine())
let testList div linkedList=
    let elem=find (fun x -> x%div<>0) linkedList
    match elem with
    | Failure s -> printfn "%s All elements are divisible by %i" s div
    | Success node -> printf "First element that is not divisible by %i is %A" div node.Value
                      let position=findi (fun i x -> x=node.Value) linkedList
                      match position with
                      | Success pos -> printfn ". The element is in position %A" pos
                      | Failure msg -> printfn "%s" msg
//      a.
testList div linkedList

//      b.
let values1=Seq.concat [[25..5..95];[97]; [100..10..150]]
let linkedList1=new LinkedList<int>(values1)
testList div linkedList1