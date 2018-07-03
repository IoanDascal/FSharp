(*
    Write a function f : int list -> int that generate an integer 
number with all even digits from a list of n digits. If the list 
doesn't contain even digits function f should return -1.
*)
open System
printf "Dati n="
let n=int(Console.ReadLine())
let vector=[for i in 1..n do yield(printf "vec[%i]=" i
                                   int(Console.ReadLine()))] 
printfn "Vector: %A" vector
let f a=
    let evenDigits=List.filter (fun x -> x%2=0) a
    printfn "Pare: %A" evenDigits
    if evenDigits.Length=0 then -1
        else 
            let digitsList=evenDigits |>List.rev
            let rec newNumber digitsList num=
                match digitsList with
                | [] -> num
                | x::xs -> newNumber xs (num*10+x)
            newNumber digitsList 0
let res=f vector
printfn "The new number is =%i" res
