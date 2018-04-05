(*
 read x  ( natural number)
 s <- 0
 f <- 2
┌ while x>1 do
│  p <- 0
│┌ while x%f=0 do
││    x <- [x/f]
││    p <- p+1
│└■
│ s <- s+p
│ f <- f+1
└■
  write s
*)

printf "x="
let x=int32(System.Console.ReadLine())
let rec whileLoop x s f=
    match x>1 with
    | false -> s
    | true -> let rec innerWhileLoop x p=
                  match x%f=0 with
                  | false -> (x,p)
                  | true -> innerWhileLoop (x/f) (p+1)
              let xp=innerWhileLoop x 0
              whileLoop (fst xp) (s+snd xp) (f+1)

let s=whileLoop x 0 2
printfn "%i" s