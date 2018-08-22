(*
    Print the content of a queue and the last extracted
element after a sequence of operations.
*)
open System.Collections.Generic
let queue=new Queue<int>()
queue.Enqueue(3)
queue.Enqueue(10)
queue.Enqueue(2)
queue.Enqueue(8)
queue.Enqueue(6)
queue.Dequeue() |>ignore
queue.Enqueue(100)
queue.Dequeue() |> ignore
queue.Dequeue() |> ignore
let last=queue.Peek()
queue.Dequeue() |> ignore
printfn "The content of the queue is : %A" queue
printfn "The last element extracted from the queue is= %i" last
printfn "The queue contains %i elements" queue.Count