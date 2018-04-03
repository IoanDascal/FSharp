(*
 read a,b ( natural numbers)
 a <- [a/10]%10*10+a%10
 b <- [b/10]%10*10+b%10
┌ for i <- a,b do
│┌ if [i/10]=i%10 then
││     write i%10
│└■
└■
*)
open System
printf " a="
let a=int(Console.ReadLine())
printf " b="
let b=int(Console.ReadLine())
let x=a/10%10*10+a%10
let y=b/10%10*10+b%10
let rec forLoop x y=
    match x>y with
    | true -> printfn ""
    | false -> match x/10=x%10 with
               | false -> forLoop (x+1) y
               | true -> printf "%i" (x%10)
                         forLoop (x+1) y
let res=forLoop x y
