(*
 read a,b,c ( natural numbers greather than 0) 
┌ while a ≠b or a≠c do
│    x <- a 
│┌ if x>b then
││    x <- b
│└■
│┌ if x>c then
││    x <- c
│└■
│┌ if x ≠ a then
││    a <- a-x
│└■
│┌ if x ≠ b then
││    b <- b-x
│└■
│┌ if x ≠ c then
││    c <- c-x
│└■
└■
 write a
*)

printf "a="
let a=uint32(System.Console.ReadLine())
printf "b="
let b=uint32(System.Console.ReadLine())
printf "c="
let c=uint32(System.Console.ReadLine())
let rec whileLoop a b c=
    match a<>b || a<>c with
    |false ->  a
    | true -> let x=if (a>b && a>c) then c else if (a>b && a<=c) then b else if (a<b && a>c) then c else a 
              //let aVal=if x<>a then a-x else a
              //let bVal=if x<>b then b-x else b
              //let cVal= if x<>c then c-x else c
              printfn "%i %i %i" a b c
              whileLoop (if x<>a then a-x else a) (if x<>b then b-x else b) (if x<>c then c-x else c)

let res=whileLoop a b c  
printfn "%i" res