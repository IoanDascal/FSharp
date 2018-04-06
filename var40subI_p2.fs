(*
 read x  ( natural number, x>0)
 d <- 2
 y <- 0
 z <- 0  
┌ while x≠1 do
│  p <- 0 
│┌ while x%d=0 do
││   p <- p+1 
││   x <- [x/d] 
│└■
│┌ if p≠0 then
││┌ if y=0 then
│││    y <- d
││└■
││  z <- d 
│└■
│  d <- d+1 
└■
 write y 
 write z 
*)

printf "x="
let x=int32(System.Console.ReadLine())
let rec whileLoop x d y z=
    match x<>1 with
    | false -> (y,z)
    | true -> let rec innerWhileLoop p x=
                  match x%d=0 with
                  | false -> (p,x)
                  | true -> innerWhileLoop (p+1) (x/d)
              let p,x=innerWhileLoop 0 x
              let y,z=if p<> 0 then 
                         if y=0 then 
                            (d,d)
                         else 
                            (y,d)
                      else
                         (y,z)
              whileLoop x (d+1) y z

let y,z=whileLoop x 2 0 0 
printfn "y=%i" y
printfn "z=%i" z
