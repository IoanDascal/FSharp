(*
    Insert in a stack and a queue numbers: 1,2,3,4.
 - Operation S -> Q extract an element from the stack and
add it to the queue;
 - Operation Q -> S eliminate an element from the queue and
insert it in the stack;
    Which is the last element inserted on the stack, and 
the last element added to the queue after the next sequence
of operations: Q -> S , Q -> S , S -> Q , Q -> S , S -> Q ,
S -> Q , Q -> S.
*)
open System.Collections.Generic
let stack=Stack<int>()
for i in 1..4 do
    stack.Push(i)
printfn "stack : %A" stack
let queue=Queue<int>()
for i in 1..4 do
    queue.Enqueue(i) 
printfn "queue : %A" queue
stack.Push(queue.Dequeue())
printfn "stack : %A" stack
printfn "queue : %A" queue
stack.Push(queue.Dequeue())
printfn "stack : %A" stack
printfn "queue : %A" queue
queue.Enqueue(stack.Pop())
printfn "stack : %A" stack
printfn "queue : %A" queue
stack.Push(queue.Dequeue())
printfn "stack : %A" stack
printfn "queue : %A" queue
queue.Enqueue(stack.Pop())
printfn "stack : %A" stack
printfn "queue : %A" queue
let last=stack.Peek()
queue.Enqueue(stack.Pop())
printfn "stack : %A" stack
printfn "queue : %A" queue
stack.Push(queue.Dequeue())
printfn "stack : %A" stack
printfn "queue : %A" queue
printfn "The last elemnt inserted in the stack is =%i" (stack.Peek())
printfn "The last element added to the queue is =%i" last