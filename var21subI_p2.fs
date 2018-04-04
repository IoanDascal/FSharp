(*
 read a,b,n ( natural numbers)
┌ if b=0 then
│    write ”wrong”
│ else
│    write [a/b]
│ ┌ if n>0 and a%b≠0 then
│ │    write ”,”
│ │    a <- a%b; i <- 0
│ │ ┌ repeat
│ │ │     write [(a*10)/b]
│ │ │     a <- (a*10)%b
│ │ │     i <- i+1
│ │ └ until i=n or a=0
│ └■
└■
*)
open System
printf " a="
let a=int(Console.ReadLine())
printf " b="
let b=int(Console.ReadLine())
printf " n="
let n=int(Console.ReadLine())
let rec repeatLoop i a=
    printf "%i" (a*10/b)
    match i=n || a=0 with
    | true -> printf ".."
    | false -> repeatLoop (i+1) (a*10%b)
let result a b n=
    match b with
    | 0 -> printf "wrong"
    | _ -> printf "%i" (a/b)
           match n>0 && a%b<>0 with
           | false -> printfn ""
           | true -> printf ","
                     repeatLoop 0 (a%b)

let res=result a b n
printfn ""
