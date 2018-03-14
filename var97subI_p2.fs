(*
┌ for i <- 1,3 do
│   read x  (natural number)
│   s <- 0 
│   ┌ for j <- 1,i do
│   │    s <- s + x % 10 
│   └■
│   write s 
└■
*)

let rec forLoop i=
    match i<=3 with
    | true -> printf " x="
              let x=int32(System.Console.ReadLine())
              let rec innerLoop s j=
                  match j<=i with
                  | false -> s
                  | true -> innerLoop (s+x%10) (j+1)
              printfn " %i" (innerLoop 0 1)
              forLoop (i+1)
    | false -> ()
let res=forLoop 1
               