(*
 read a ( natural number)
 x <- 2 
 p <- 1 
┌ while a>1 do
│  c <- 0 
│┌ while x|a do
││    c <- x   
││    a <- [a/x] 
│└■
│┌ if c ≠ 0 then
││    p <- p*c 
│└■
│  x <- x+1 
└■
 write p  
*)

printf "a="
let a=int(System.Console.ReadLine())
let rec whileLoop a x p=
    match a>1 with
    | false -> p
    | true -> let rec innerLoop a c=
                  match a%x=0 with
                  | false -> (a,c)
                  | true -> innerLoop (a/x) x
              let c=innerLoop a 0
              match (snd c)<>0 with
              | false -> whileLoop (fst c) (x+1) p
              | true -> whileLoop (fst c) (x+1) (p*(snd c))

let res =whileLoop a 2 1
printfn "%i" res
