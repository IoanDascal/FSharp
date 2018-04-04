(*
 read n ( natural number)
 m <- 0
 p <- 1
┌ while n>0 do
│    c <- n%10
│ ┌ if c>0 then
│ │    c <- c-1
│ └■
│   m <- m+c*p
│   p <- p*10
│   n <- [n/10]
└■
 write m 
*)
printf " n="
let n=int(System.Console.ReadLine())
let rec whileLoop n m p c=
    match n>0 with
    | false -> m
    | true -> match c>0 with
              | true -> whileLoop (n/10) (m+(c-1)*p) (p*10) (n/10%10)
              | false -> whileLoop (n/10) (m+c*p) (p*10) (n/10%10)
let m=whileLoop n 0 1 (n%10)
printfn "%i" m
