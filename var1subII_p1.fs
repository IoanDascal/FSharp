open System.Collections.Generic
let coada=new Queue<int>()
coada.Enqueue(1)
coada.Enqueue(2)
coada.Enqueue(4)
coada.Dequeue() |> ignore
coada.Dequeue() |> ignore
coada.Enqueue(5)
coada.Dequeue() |> ignore
coada.Enqueue(3)
printfn "%A" coada