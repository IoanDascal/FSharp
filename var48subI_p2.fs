(*
 read n    ( natural number, n>0 )
┌ for i <- 1,n do
│    read x  ( natural number)
│    nr <- 0 
│┌ while x>0 do
││    nr <- nr*100+x%10 
││    x <- [x/100] 
│└■
│┌ while nr>0 do
││    x <- x*10+nr%10 
││    nr <- [nr/10] 
│└■
│  write x 
└■
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec forLoop i n=
    match i<=n with 
    | false -> ()
    | true -> printf "x="
              let x=int32(System.Console.ReadLine())
              let rec whileLoop1 x nr=
                  match x>0 with
                  | false -> nr
                  | true -> whileLoop1 (x/100) (nr*100+x%10)
              let nr=whileLoop1 x 0
              let rec whileLoop2 nr x1=
                  match nr>0 with
                  | false -> x1
                  | true -> whileLoop2 (nr/10) (x1*10+nr%10)
              let x1=whileLoop2 nr 0
              printfn "x=%i" x1
              forLoop (i+1) n

let res=forLoop 1 n 


