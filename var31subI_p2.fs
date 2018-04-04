(*
 read a  ( natural number, a>0)
 k <- 0
 b <- [(a+1)*(a+2)/2]
┌ while b≥a do
│    b <- b-a
│    k <- k+1
└■
  write b,k 
*)
printf " a="
let a=int(System.Console.ReadLine())
let rec whileLoop b k=
    match b>=a with
    | false -> (b,k)
    | true -> whileLoop (b-a) (k+1)
let b,k=whileLoop ((a+1)*(a+2)/2) 0
printfn "b=%i   k=%i" b k
