(*
    Write a function that print the content of a stack
after a number of operations on it.
*)

type ImmutableStack<'T>=
    | Stack of 'T list
    member s.Top()=
        match s with
        | Stack([]) -> failwith "The stack is empty"
        | Stack(hd::_) -> hd
    member s.Push x =
        match s with
        | Stack([]) -> Stack([x])
        | Stack(s) -> Stack(x::s)  
    member s.Pop()=
        match s with
        | Stack([]) -> failwith "The stack is empty"
        | Stack(_::tail) -> Stack(tail) 
    member s.ISEmpty=
        match s with
        | Stack([]) -> true
        | _ -> false

let s=ImmutableStack<int>.Stack([])
let s1=s.Push 1
let s2=s1.Push 2
let s3=s2.Push 3
printfn "%i" (s3.Top())
let s4=s3.Pop()
printfn "%A" s4
let s5=s4.Push 5
printfn "%A" s5