(*
 read n   ( natural number)
 r <- 0 
┌ repeat
│   r <- (r*10+n%10)*10
│   n <- [n/100]
└ until n<10 
 write r 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec repeatLoop n r=
    let r=(r*10+n%10)*10
    let n=n/100
    match n<10 with
    | true -> r 
    | false -> repeatLoop n r 

let r=repeatLoop n 0
printfn "r=%i" r 