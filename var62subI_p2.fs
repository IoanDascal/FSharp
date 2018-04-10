(*
  read x   ( natural number)
  aux <- x
  t <-1
┌ while aux>9 do
│    aux <- aux/10
│    t <- t*10
└■
  aux <- x
┌ repeat
│    c <- x%10
│    x <- [x/10]
│    x <- c*t+x
│    write x
└ until x=aux 
*)

printf "x="
let x=int32(System.Console.ReadLine())
let rec whileLoop x t=
    match x>9 with
    | false -> t
    | true -> whileLoop (x/10) (t*10)
let t=whileLoop x 1
let aux=x
let rec repeatLoop x=
    let c=x%10
    let x=c*t+x/10
    printf "%i " x
    match x=aux with
    | true -> ()
    | false -> repeatLoop x

let res=repeatLoop x