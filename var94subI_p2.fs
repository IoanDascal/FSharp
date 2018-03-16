(*
 read n  ( natural number, n>0) 
 n1 <- 0   
 n2 <- 0 
 k1 <- 0 
┌ while n ≠ 0 do
│┌ if (n%10)%2=0 then
││    n2 <- n2 * 10 + n%10 
││ else
││    n1 <- n1 * 10 + n%10 
││    k1 <- k1+1 
│└■
│ n <- [n/10] 
└■
 p <- 1 
┌ for i <- 1,k1 do
│     p <- p * 10 
└■
 x <- n2*p + n1 
 write x 
*)

printf "n="
let n=uint32(System.Console.ReadLine())
let rec whileLoop (n:uint32) n1 n2 k1=
    match n>0u with
    | false -> (n1,n2,k1)
    | true -> match (n%10u)%2u=0u with
              | true -> whileLoop (n/10u) n1 (n2*10u+n%10u) k1 
              | false -> whileLoop (n/10u) (n1*10u+n%10u) n2 (k1+1u)
let (n1,n2,k1)=whileLoop n 0u 0u 0u
let p=pown 10u (int32 k1)
let res=n2*p+n1
printfn "%A" res