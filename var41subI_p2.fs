(*
 read x   ( natural number) 
 d <- 2 
 write x 
┌ while x≥d do
│┌ while x%d=0 do
││    x <- [x/d] 
││    write x 
│└■
│  d <- d+1 
└■
*)

printf "x="
let x=int32(System.Console.ReadLine())
printf "%i " x
let rec whileLoop x d=
    match x>=d with
    | false -> ()
    | true -> let rec innerWhileLoop x=
                  match x%d=0 with
                  | true -> printf "%i " (x/d)
                            innerWhileLoop (x/d)
                  | false -> x
              let x1=innerWhileLoop x
              whileLoop x1 (d+1)
let res=whileLoop x 2

