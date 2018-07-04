(*
    An integer number x can be inserted into a stack only if the value
from the top of the stack is bigger than x; otherwise the elements from 
the top of the stack should be eliminated until x can be inserted.
    Write a function to insert a list of integer numbers into an empty stack.
*)
open System.Collections.Generic
let stack=new Stack<int>()
stack.Push(40)
stack.Push(22)
stack.Push(20)
stack.Push(18)
stack.Push(10)
stack.Push(2)
let InStack (stack:Stack<int>) nr=
    if stack.Count=0 then stack.Push(nr)
        else
            while stack.Peek()<nr do 
                stack.Pop() |> ignore
            stack.Push(nr)
let res=InStack stack 11
printfn "%A" stack
let list=[20;5;16;9;3;7;5;4;8]
stack.Clear()
let insertIntoStack=List.iter (fun x -> (InStack stack x)) list
for el in stack do
    printf "%i " el