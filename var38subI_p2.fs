(*
 read n ( natural number)
┌ for i←1,n do
│   p ← 1
│┌ for j ← i,2,-1 do
││    p ← p*j
│└■
│  write [p/(i*2)]
└■
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec forLoop i n=
    match i<=n with
    | false -> ()
    | true -> let rec innerForLoop j p=
                  match j>=2 with
                  | false -> p
                  | true -> innerForLoop (j-1) (p*j)
              let p=innerForLoop i 1
              printfn "%i" (p/(i*2))
              forLoop (i+1) n

let res=forLoop 1 n