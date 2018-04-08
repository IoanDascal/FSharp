(*
 read n  ( natural number) 
 s <- 0 
 nr <- 0 
┌ while n≠0 do
│┌ if n%2=0 then
││    s <- s*10+n%10 
│└■
│  n <- [n/10] 
└■
┌ if s≠0 then
│    nr <- 1 
└■
 write nr 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop n s=
    match n<>0 with
    | false -> s
    | true -> whileLoop (n/10) (if n%2=0 then (s*10+n%10) else s)
let s=whileLoop n 0
printfn "s=%i" s
let nr=if s<>0 then 1 else 0
printfn "nr=%i" nr
