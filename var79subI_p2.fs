(*
 read a  ( natural number)
 x <- 2 
 k <- 0 
┌ while a>1 do
│   c <- 0 
│┌ while x|a do
││   c <- x 
││   a <- [a/x] 
│└■
│┌ if c ≠ 0 then
││   k <- k+x  
│└■
│  x <- x+1 
└■
 write k  
*)

open System
printf "a="
let a=int32(Console.ReadLine())
let rec whileLoop a x k=
    match a>1 with
    | false -> k
    | true -> let rec innerLoop a c=
                  match a%x=0 with
                  | false -> (a,c)
                  | true -> innerLoop (a/x) x
              let res=innerLoop a 0
              whileLoop (fst res) (x+1) (if (snd res)<>0 then k+x else k)

let k=whileLoop a 2 0
printfn "%i" k
              
