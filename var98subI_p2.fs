(*

read  n  (integer number) 
┌ if n<0 then
│   n <-  -n 
└■
i <- 1 
┌ while i*i ≤ n do
│   i <- i+1 
└■
write i-1 

*)
printf "n="
let n=int32(System.Console.ReadLine())
let absValue x=
    match x<0 with
    | true -> -x
    | false -> x
let N=absValue n
let rec whileLoop i=
    match i*i <= N with
    | true -> whileLoop (i+1)
    | false -> i

let res=whileLoop 1
printfn "i=%i" (res-1)