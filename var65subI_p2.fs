(*
 read n  ( natural number, 0< n ≤ 10000)
 m <- 0
 v <- n
 u <- n%10
┌ repeat
│    c <- n%10
│    v <- v*10+c
│ ┌ if c=u then
│ │    m <- m+1
│ └■
│   n <- [n/10]
└ until n=0
  write v, m 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let u=n%10
let rec repeatLoop n m v=
    let c=n%10
    let v=v*10+c
    let m=if c=u then (m+1) else m
    match n<10 with
    | true -> v,m
    | false -> repeatLoop (n/10) m v

let v,m=repeatLoop n 0 n  
printfn "v=%i  m=%i" v m