(*
 read a,n  ( natural numbers)
 j <- 3
┌ for i=1,n do
│┌ if i%2=0 then
││    a <- a-j
││ else
││    a <- a+j
│└■
│  j <- 7-j
└■
 write a
*)
printf " a="
let a=int(System.Console.ReadLine())
printf " n="
let n=int(System.Console.ReadLine())
let rec forLoop a i j=
    match i<=n with
    | false -> a
    | true -> match i%2=0 with
              | true -> forLoop (a-j) (i+1) (7-j)  
              | false -> forLoop (a+j) (i+1) (7-j)

let res= forLoop a 1 3
printfn "%i" res