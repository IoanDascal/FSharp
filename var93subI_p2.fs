(*
read n,m ( natural numbers, n≤m )
s <- 0 
┌ while n<m do
│   s <- s+n 
│   n <- n+3 
└■
┌ if n=m  then
│   scrie s+n 
│ else
│   scrie 0  
└■
*)

printf "n="
let n=uint32(System.Console.ReadLine())
printf "m="
let m=uint32(System.Console.ReadLine())
let rec whileLoop n s=
    match n<m with
    | false -> (n,s)
    | true -> whileLoop (n+3u) (s+n)
let res=whileLoop n 0u
if (fst res)=m then
    printfn "%i" ((fst res)+(snd res))
    else 
        printfn "0"