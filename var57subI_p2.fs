(*
 read n   ( natural number)
 q <- 1 
 i <- 1 
┌ while i<[n/i] do
│┌ if n%i=0 then
││    q <- q+i
│└■
│  i <- i+3 
└■
 write q 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop i q=
    match i<n/i with
    | false -> q
    | true -> let q=if n%i=0 then (q+i) else q
              whileLoop (i+3) q

let q=whileLoop 1 1
printfn "q=%i" q