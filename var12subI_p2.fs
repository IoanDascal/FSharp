(*
 read x   ( natural number) 
 y <- 0 
┌ while x ≠ 0 do
│┌ while x>9 do
││   x <- [x/10] 
│└■
│ y <- y*10+x 
│ read x 
└■
 write y 
*)

printf " x="
let x=int(System.Console.ReadLine())
let rec whileLoop x y=
    match x with
    | 0 -> y
    | _ -> let rec firstDigit x=
               match x>9 with
               | false -> x
               | true -> firstDigit (x/10)
           let y=y*10+firstDigit x
           printf " x="
           let x=int(System.Console.ReadLine())
           whileLoop x y

let res=whileLoop x 0
printfn "%i" res