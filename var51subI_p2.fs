(*
 read x   ( natural number, n>0) 
 z <- 0 
┌ repeat
│    c <- x%10 
│┌ if c%2≠0 then
││    z <- z*10+c-1 
││ else  
││    z <- z*10+c 
│└■
│  x <- [x/10] 
└ until x = 0 
  write z 
*)

open System
printf "x="
let x=int32(Console.ReadLine())
let rec repeatLoop x z=
    match x=0 with
    | true -> z
    | false -> let c=x%10
               let z=if c%2<>0 then (z*10+c-1) else (z*10+c)
               repeatLoop (x/10) z
    
let z=repeatLoop x 0
printfn "z=%i" z