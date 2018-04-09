(*
 read n  ( natural number)
┌ repeat
│    n <- n+n%10 
│    n <- [n/10] 
└ until n<10 
 write n 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec repeatLoop n=
    let n=(n+n%10)/10
    match n<10 with
    | true -> n 
    | false -> repeatLoop n

let n1=repeatLoop n
printfn "n=%i" n1