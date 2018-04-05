(*
 read n ( natural number)
 nr <- 0
 p <- 1
┌ while n≠0 do
│  c <- n%10
│┌ if c>0 and c < 9 then
││    c <- c+1
│└■
│  nr <- nr+c*p
│  p <- p*10
│  n <- [n/10]
└■
 write nr 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec whileLoop n nr p=
    match n<>0 with
    | false -> nr
    | true -> let c=if n%10>0 && n%10<9 then n%10+1 else n%10
              whileLoop (n/10) (nr+c*p) (p*10)

let nr=whileLoop n 0 1
printfn "%i" nr