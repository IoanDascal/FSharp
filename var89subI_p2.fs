(*
read n ( natural number)
 t <- n; r <- 0
┌ while t>0 do
│┌ if (t%10)%2=1 then
││    r <- r*10+1
││ else
││    r <- r*10+t%10
│└■
│ t <- [t/10]
└■
 n <- 0
┌ while r>0 do
│     n <- n*10+r%10
│     r <- [r/10]
└■
 write n 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop1 t r=
    match t>0 with  
    | false -> r
    | true -> match (t%10)%2=1 with
              | true -> whileLoop1 (t/10) (r*10+1)
              | false -> whileLoop1 (t/10) (r*10+t%10)

let res1=whileLoop1 n 0
let rec whileLoop2 n r=
    match r>0 with
    | false -> n
    | true -> whileLoop2 (n*10+r%10) (r/10)

printfn "%i" (whileLoop2 0 res1)