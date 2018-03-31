(*
 read m  ( natural number, m<10) 
 read n (natural number, n>1) 
┌ for i <- 1,n do
│    read x  (natural number)
│    aux <- x 
│    ok <- 0 
│┌ while x>0 do
││┌ if x%10=m then
│││    ok <- 1 
││└■
││  x <- [x/10] 
│└■
│┌ if ok=1 then 
││    write aux 
│└■
└■
*)

open System
printf "m="
let m=uint32(Console.ReadLine())
printf "n="
let n=uint32(Console.ReadLine())
let rec whileLoop x ok=
    match x>0u with
    | false -> ok
    | true -> let ok1=if x%10u=m then 1u else ok
              whileLoop (x/10u) ok1

let rec forLoop i=
    match i<=n with
    | false -> ()
    | true -> printf "x="
              let x=uint32(Console.ReadLine())
              if (whileLoop x 0u)=1u then
                  printf "%u" x
                  forLoop (i+1u)
              else
                  forLoop (i+1u)

let res=forLoop 1u
