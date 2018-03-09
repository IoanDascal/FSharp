open System.Collections.Generic
let coada=new Queue<int>()
coada.Enqueue(3)
coada.Enqueue(10)
coada.Enqueue(2)
coada.Enqueue(8)
coada.Enqueue(6)
coada.Dequeue() |>ignore
coada.Enqueue(100)
coada.Dequeue() |> ignore
coada.Dequeue() |> ignore
coada.Dequeue() |> ignore
printfn "%A" coada