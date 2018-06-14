(*
    Given a linked list, write a function to calculate the 
sum of elements divisible with 5.
*)
open System.Collections.Generic
let linkedList=new LinkedList<int>()
printf "Enter the number of nodes from list n="
let n=int(System.Console.ReadLine())
for i in 1..n do
    printf "Enter list[%i]=" i
    let list=linkedList.AddFirst(int(System.Console.ReadLine()))
    list |> ignore

let sumDiv5= Seq.fold (fun acc x -> match x%5 with
                                     | 0 -> acc+x
                                     | _ -> acc) 0 linkedList
printfn "The sum of elements divisible with 5 is =%i" sumDiv5