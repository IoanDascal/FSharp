(*
 read n  ( natural number, n>0)
 s <- 0 
┌ while n>0 do
│    c <- n%10 
│┌ if c%2=0 then
││    p <- 1 
││┌ for i <- 2,c do
│││     p <- p*i 
││└■
││  s <- s+p 
│└■
│  n <- [n/10] 
└■
 write s 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop n s=
    match n>0 with
    | false -> s 
    | true -> let c=n%10
              let s=
                  match c%2=0 with
                  | false -> s 
                  | true -> let rec forLoop i p=
                                match i<=c with
                                | false -> p 
                                | true -> forLoop (i+1) (p*i)
                            let p=forLoop 2 1
                            let s=s+p 
                            s 
              whileLoop (n/10) s

let s=whileLoop n 0
printfn "s=%i" s 