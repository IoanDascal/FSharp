(*
    ( [x] is the integer part of the real number x )
 read n ( natural number, n>0) 
 nr <- 0 
 y <- 0 
┌ for i <- 1,n do
│┌ repeat
││   read x ( real number)
││   nr <- nr+1
│└ while x<1 or x>10 
│  y <- y+x 
└■
 write [y/n] 
 write nr     
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec repeatLoop nr=
    printf "x="
    let x=float(System.Console.ReadLine())
    match x>=1.0 && x<=10.0 with
    | true -> (x,(nr+1))
    | false -> repeatLoop (nr+1)

let rec forLoop i y nr=
    match i<=n with
    | false -> (y,nr)
    | true -> let rs=repeatLoop nr
              forLoop (i+1) (y+fst rs) (snd rs)

let res=forLoop 1 0.0 0
printfn "%f" (fst res)
printfn "%i" (snd res)
