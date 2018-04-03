(*
 read x ( natural number)
 n <- 0
┌ while x≠0 do
│ y <- x ; c <- 0
│ ┌ while y>0 do
│ │ ┌ if y%10>c then
│ │ │    c <- y%10
│ │ └■
│ │  y <- [y/10]
│ └■
│ n <- n*10+c
│ read x
└■
 write n
*)
open System
printf " x="
let x=int(Console.ReadLine())
let rec innerWhileLoop y c=
    match y with
    | 0 -> c
    | _ -> match y%10>c with
            | true -> innerWhileLoop (y/10) (y%10)
            | false -> innerWhileLoop (y/10) c
let rec whileLoop x n=
    match x with
    | 0 -> n
    | _ -> let c=innerWhileLoop x 0
           printf " x="
           let x=int(Console.ReadLine())
           whileLoop x (n*10+ c)

let res=whileLoop x 0
printfn "%i" res
            