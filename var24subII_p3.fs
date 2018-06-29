(*
    In a stack S and in a queue C are inserted in order numbers 1,2,3,4.
    - S -> C is the operation to extract an element from the stack and add
it to the queue;
    - C -> S is the operation to eliminate an element from the queue and 
insert it in the stack. 
    Print the content of the queue and the stack after the next sequence of
operations : S -> C , C -> S , C -> S , S -> C , C -> S.
*)

type Stack<'a>()=
    let mutable stack : List<'a>=[] 
    member x.Push value=
        stack <- value::stack 
    member x.TryPop =
        match stack with
        | hd::tail -> stack <- tail
                      hd |> Some
        | [] -> None
    member x.TryTop=
        match stack with
        | hd::_ -> Some hd  
        | [] -> None
    member x.IsEmpty=
        match stack with
        | [] -> true
        | _ -> false
    

type Queue<'a>()=
    let mutable queue : List<'a>=[]
    member x.Enqueue value=
        queue <- queue@[value]
    member x.TryDequeue=
        match queue with
        | hd::tail -> queue <- tail
                      hd |> Some
        | [] -> None
    member x.IsEmpty=
        match queue with
        | [] -> true
        | _ -> false

let stack=new Stack<int>()
stack.Push 1
stack.Push 2
stack.Push 3
stack.Push 4
let queue=new Queue<int>()
queue.Enqueue 1
queue.Enqueue 2
queue.Enqueue 3
queue.Enqueue 4

queue.Enqueue (stack.TryPop.Value)
stack.Push (queue.TryDequeue.Value)
stack.Push (queue.TryDequeue.Value)
let lastEnqueue=stack.TryTop.Value
queue.Enqueue (stack.TryPop.Value)
stack.Push (queue.TryDequeue.Value)

printfn "The last value inserted in stack is : %i" stack.TryTop.Value
printfn "The last value inserted in queue is : %i" lastEnqueue
printf "Stack : "
while (not stack.IsEmpty) do  
    printf "%i " stack.TryPop.Value
printfn ""
printf "Queue : "
while (not queue.IsEmpty) do  
    printf "%i " queue.TryDequeue.Value
printfn ""