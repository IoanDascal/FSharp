(*
    a) Write a function shift: int list -> int list, which make a
cyclic permutation of one place to the left for a list of n elements.
Example: [1;2;3;4] -> [2;3;4;1]
    b) Write a function to reverse the order of elements from a list
using the function shift. 
Example: [1;2;3;4;5] -> [5;4;3;2;1]
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())

let intList=[for i in 1..n do
                 printf "Enter a number <10000 = "
                 yield(int(Console.ReadLine()))
                 ]
printfn "%A" intList
let shift (intList:int list)= 
    List.append intList.Tail [intList.Head]

printfn "Permutation=%A" (shift intList)

let rec reverse n (lst :int List)=
    match n with 
    | 1 -> lst
    | _ -> let first,second=List.splitAt (n) lst 
           reverse (n-1) (List.append (shift first) second)

let invers=reverse n intList
printfn "%A" invers