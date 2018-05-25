(*
    Given a sequence with the rule:  f(n)= |  n , if n<=5
                                           | 2*f(n-1), if n>5
 - Write a function sub:int -> int -> int that takes a number nr 
and return the biggest number, lower than nr, that is a term of 
the sequence f. 
 - Write a function sequence:int list -> int -> int list that takes
a number s and return a list with terms from the sequence f. The sum 
of the elements from the list must be equal to s.
*)
open System
printf "Enter s="
let s=int(Console.ReadLine())
let rec sub number nr=   
    match number>nr with
    | true -> match nr<5 with
              | true -> number-1
              | false -> number/2
    | false -> match number >=5 with 
               | true -> sub (2*number) nr
               | false -> sub (number+1) nr 

let res=sub 0 s
printfn "The biggest number, lower than %i, that is term of the sequence is=%i" s res
let rec sequence xs n=
    match n with
    | 0 -> xs
    | _ -> let res=sub 0 n
           sequence (res::xs) (n-res)

let sList=sequence [] s
printfn "The list of numbers is : %A and the sum =%i" sList (List.sum sList)