(*
 read a  ( natural number)
 b <- 0 
 p <- 1 
┌ while a>0 do
│  c <- a%10 
│┌ if c%2 ≠ 0 then
││    b <- b+p*c 
││    p <- p*10 
│└■
│  a <- [a/10] 
└■
 write b 
*)

printf "a="
let a=int32(System.Console.ReadLine())
let rec whileLoop a b p=
    match a>0 with
    | false -> b
    | true -> let c=a%10
              match c%2<>0 with
              | true -> whileLoop (a/10) (b+p*c) (p*10)
              | false -> whileLoop (a/10) b p

let res=whileLoop a 0 1
printfn "%i" res
