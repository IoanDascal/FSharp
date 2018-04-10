(*
 read n  ( natural number, n>0)
 k <- 0
┌ for i <- 1,n do
│┌ for j <- 1,i do
││     write i+j
││     k <- k+1
│└■
└■
  write k 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec forLoop i k=
    match i<=n with
    | false -> k 
    | true -> let rec innerForLoop j k=
                  match j<=i with
                  | false -> k
                  | true -> printf "%i " (i+j)
                            innerForLoop (j+1) (k+1)
              let k=innerForLoop 1 k
              forLoop (i+1) k

let k=forLoop 1 0
printfn "k=%i" k