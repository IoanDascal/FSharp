(*
    Compute the two biggest distinct prime numbers less or equal with n.
*)
open System
printf " n="
let n=int(Console.ReadLine())
let lista=[]
let rec prim nr div=
    match div with
    | 1 -> true
    | _ -> match nr%div=0 with
           | true -> false
           | false -> prim nr (div-1)
let rec sub n (lista:list<int>)=
    match lista.Length with
    | 2 -> lista
    | _ -> if (prim n (n/2)) then 
               sub (n-1) (n::lista)
           else
               sub (n-1) lista

let test=sub n lista
printfn "%A" (List.rev test )