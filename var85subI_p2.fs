(*
 read n ( natural number, n>1)
 ok <- 0
┌ while n>0 do
│  c <- n%10
│┌ if c%2=1 then
││     ok1 <- 1
││ else
││     ok1 <- 0
│└■
│┌ if ok1=1 then
││     write c,’ ’
││     ok <-1
│└■
│  n <- [n/10]
└■
┌ if ok=0 then
│     write ”NO”
└■    
*)

printf "n="
let n=uint32(System.Console.ReadLine())
let rec whileLoop (n:uint32) ok =
    match n>0u with  
    | false -> ok
    | true -> let ok1=if n%2u=1u then 1 else 0
              let ok=if ok1=1 then  
                        printf "%u " (n%10u)
                        1
                     else 
                        ok
              whileLoop (n/10u) ok
if (whileLoop n 0)=0 then printfn "NO" else ()
printfn ""
