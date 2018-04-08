(*
 read n  ( natural number, n>0)  
 max <- 0 
┌ repeat
│   n <- [n/10] 
│┌ if max<n%10 then
││    max <- n%10 
│└■
└ until n=0 
 write max 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec repeatLoop n max=
    let n=n/10
    let max=if max<n%10 then (n%10) else max
    match n=0 with
    | true -> max
    | false -> repeatLoop n max

let max=repeatLoop n 0
printfn "max=%i" max
