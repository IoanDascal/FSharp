open System.Collections.Generic
let stiva=Stack<int>()
for i in 1..4 do
    stiva.Push(i)
printfn "stiva : %A" stiva
let coada=Queue<int>()
for i in 1..4 do
    coada.Enqueue(i) 
printfn "coada : %A" coada
stiva.Push(coada.Dequeue())
printfn "stiva : %A" stiva
printfn "coada : %A" coada
stiva.Push(coada.Dequeue())
printfn "stiva : %A" stiva
printfn "coada : %A" coada
coada.Enqueue(stiva.Pop())
printfn "stiva : %A" stiva
printfn "coada : %A" coada
stiva.Push(coada.Dequeue())
printfn "stiva : %A" stiva
printfn "coada : %A" coada
coada.Enqueue(stiva.Pop())
printfn "stiva : %A" stiva
printfn "coada : %A" coada
coada.Enqueue(stiva.Pop())
printfn "stiva : %A" stiva
printfn "coada : %A" coada
stiva.Push(coada.Dequeue())
printfn "stiva : %A" stiva
printfn "coada : %A" coada