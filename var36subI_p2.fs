(*
 s <- 0
 read v ( natural number)
┌ while v ≠ 0 do
│    a <- v%10
│    b <- [v/10]%10
│    s <- s + a*10 + b
│    read v
└■
 write s 
*)

open System
printf "v="
let v=int32(Console.ReadLine())
let rec whileLoop v s =
    match v<>0 with
    | false -> s
    | true -> let a=v%10
              let b=(v/10)%10 
              printf "v="
              let v=int32(Console.ReadLine())
              whileLoop v (s+a*10+b)

let s=whileLoop v 0
printfn "%i" s