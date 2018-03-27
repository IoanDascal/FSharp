(*
 read a  ( natural number)
 p <- 1
 b <- 0
┌ while a≠0 do
│   c <- a%10
│ ┌ if a%2=0 then
│ │    b <- b+c*p
│ │ else
│ │    b <- b*10+c
│ └■
│  a <- [a/10]
│  p <- p*10
└■
 write b 
*)

printf "a="
let a=uint32(System.Console.ReadLine())
let rec whileLoop p b a=
    match a>0u with
    | false -> b
    | true -> let c=a%10u
              match a%2u with
              | 0u -> whileLoop (p*10u) (b+c*p) (a/10u)
              | _ -> whileLoop (p*10u) (b*10u+c) (a/10u)

let res=whileLoop 1u 0u a
printfn "%i" res