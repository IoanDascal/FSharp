(*
 read a,b ( natural numbers >0)
 c <- 0
 p <- 0
┌ while a + b > 0 do
│┌ if a%10 = b%10 şi a%2=0 then
││    c <- c*10 + b%10
││ else
││    p <- p*10 + a%10
│└■
│  a <- [a/10]
│  b <- [b/10]
└■
 write c, p 
*)

open System
printf "a="
let a=int32(Console.ReadLine())
printf "b="
let b=int32(Console.ReadLine())
let rec whileLoop a b c p=
    match a+b>0 with
    | false -> (c,p)
    | true -> match a%10=b%10 && a%2=0 with
              | true -> whileLoop (a/10) (b/10) (c*10+b%10) p   
              | false -> whileLoop (a/10) (b/10) c (p*10+a%10)
let res=whileLoop a b 0 0
printfn "c=%i  p=%i" (fst res) (snd res)