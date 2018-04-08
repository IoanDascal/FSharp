(*
 read x  ( natural number, n>0)
 k <- 0 
┌ while x≠0 do
│    k <- k*10+x%10 
│    x <- [x/10] 
└■
┌ while k≠0 do
│    x <- x*10+k%10 
│    k <- [k/100] 
└■
 write x 
*)

printf "x="
let x=int32(System.Console.ReadLine())
let rec whileLoop1 x k=
    match x<> 0 with
    | false -> (k,x)
    | true -> whileLoop1 (x/10) (k*10+x%10)
let k,x1=whileLoop1 x 0
let rec whileLoop2 k x1=
    match k<>0 with
    | false -> x1
    | true -> whileLoop2 (k/100) (x1*10+k%10)

let x2=whileLoop2 k x1
printfn "x=%i" x2
