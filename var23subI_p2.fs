 (*
  read a,b  ( natural numbers >0)
  c <- 0
┌ repeat
│   i <- a%2
│   j <- b%2
│ ┌ if i+j=0 then
│ │    c <- c+1
│ └■
│  a <- a*i+(1-i)*[a/2]
│  b <- b*j+(1-j)*[b/2]
└■ until i*j=1
 write c
*)
open System
printf " a="
let a=int(Console.ReadLine())
printf " b="
let b=int(Console.ReadLine())
let rec repeatLoop a b c=
    let i=a%2
    let j=b%2 
    match i*j with
    | 1 -> c
    | _ -> match (i+j) with
           | 0 -> repeatLoop (a*i+(1-i)*(a/2)) (b*(j)+(1-j)*(b/2)) (c+1)
           | _ -> repeatLoop (a*(i)+(1-i)*(a/2)) (b*(j)+(1-j)*(b/2)) c

let res=repeatLoop a b 0
printfn "%i" res
printfn ""