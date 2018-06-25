(*
    In a stack they were inserted next values: 1,2,3,4,5,6,7.
How many values must be eliminated from the stack so that the 
value from the top of the stack to be 5.
*)
open System.Collections.Generic
let stack=Stack<int>()
for i in 1..7 do
    stack.Push(i) 
printfn "%A" stack
printfn "The element from the top of the stack is %i" (stack.Peek())
let rec count nr=
    match stack.Peek() with 
    | 5 -> nr
    |_ -> stack.Pop() |> ignore
          count (nr+1)
let num=count 0
printfn "They were eliminated %i values" num
printfn "The element from the top of the stack is %i" (stack.Peek())
stack.Pop() |>ignore
printfn "The element from the top of the stack is %i" (stack.Peek())
stack.Pop() |> ignore
printfn "The element from the top of the stack is %i" (stack.Peek())