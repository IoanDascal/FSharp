(*
 read a ( natural number)
 k <- 0 
┌ while a ≠ 0 do
│    read b ( natural number)
│┌ if a%10 = b%10 then
││     k <- k+1 
│└■
│  a <- b 
└■
 write k 
*)

printf "a="
let a =int(System.Console.ReadLine())
let rec whileLoop a k=
    match a<>0 with
    | false -> k
    | true -> printf "b="
              let b=int(System.Console.ReadLine())
              match a%10=b%10 with
              | true -> whileLoop b (k+1)
              | false -> whileLoop b k

let k=whileLoop a 0
printfn "%i" k
