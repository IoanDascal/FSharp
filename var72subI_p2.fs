(*
  read n ( natural number, n>0)
┌ for i <- 1,2*n-1 do
│     b <- 0
│ ┌ if  n-i < 0 then
│ │     j <- i-n
│ │ else
│ │     j <- n-i
│ └■
│ ┌ while j ≥ 0 do
│ │     write „*”
│ │     j <- j-1
│ │     b <- 1
│ └■
│ ┌ if b ≠ 0 then
│ │   go to new line '\n'
│ └■
└■
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec forLoop i n=
    match i<=2*n-1 with
    | false -> ()
    | true -> let j=if n-i<0 then i-n else n-i
              let rec whileLoop j b=
                  match j>=0 with
                  | false -> b
                  | true -> printf "*"
                            let b=1
                            whileLoop (j-1) b
              let b=whileLoop j 0
              if b<>0 then printfn ""
              forLoop (i+1) n

let res=forLoop 1 n