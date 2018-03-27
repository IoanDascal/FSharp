(*
    A queue contains items 1 and 2.  AD(x) is the operation to add the 
  element with value x in  queue and  EL is the operation to eliminate an
  element from the queue.  What will be the elements in the queue after 
  executing the next sequence of operations  : AD(4);EL;EL;AD(5);EL;AD(3) ?
 *)
open System.Collections.Generic
let queue=new Queue<int>()
queue.Enqueue(1)
queue.Enqueue(2)
queue.Enqueue(4)
queue.Dequeue() |> ignore
queue.Dequeue() |> ignore
queue.Enqueue(5)
queue.Dequeue() |> ignore
queue.Enqueue(3)
printfn "%A" queue