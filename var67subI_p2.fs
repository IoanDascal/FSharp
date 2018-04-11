(*
 read n ( natural number)
 z <- 0
┌ while n>0 do
│    c <- n%10
│    n <- [n/10]
│┌ if c<5 then
││   z <- z*10+2*c
│└■
└■
 write z 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop n z =
    match n>0 with
    | false -> z
    | true -> let c=n%10
              let z=if c<5 then (z*10+2*c) else z
              whileLoop (n/10) z

let z=whileLoop n 0
printfn "z=%i" z
