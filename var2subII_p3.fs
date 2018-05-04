(*
    Simple operations with stack.
*)
open System.Collections.Generic
let stack=new Stack<int>()
stack.Push(1)
stack.Push(2)
stack.Push(3)
stack.Push(4)
stack.Pop() |> ignore
stack.Push(5)
stack.Pop() |> ignore
stack.Push(6)
stack.Pop() |> ignore
stack.Pop() |> ignore
stack.Push(8)
printfn "%A" stack
printfn "The top element of the stack is=%i" (stack.Peek())
let nrOfElements=stack.Count
printfn "The stack has %i elements" nrOfElements
let rec sumOfElements acc=
   match stack.Count with
   | 0 -> acc
   | _ -> sumOfElements (acc+stack.Pop())
let total=sumOfElements 0 
printfn "Sum of elements from the stack=%i" total