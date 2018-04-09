(*
 read n   ( natural number) 
 c <- 10
┌ while n%2=1 do
│    c <- n%10 
│    n <- [n/10] 
└■
 write c 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop n c=
    printfn "%i  %i" n c 
    match n%2=1 with
    | false -> c 
    | true -> whileLoop (n/10) (n%10)

let c=whileLoop n 10
printfn "c=%i" c 