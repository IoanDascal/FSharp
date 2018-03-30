(*
 read n, k  ( natural numbers >0)
┌ for i <- 1,n do
│ ┌ if [i/k]=0 then
│ │    write i
│ │    k <- k-1
│ │ else
│ │    write i%k
│ └■
└■  
*)
open System
printf "n="
let n=uint32(Console.ReadLine())
printf "k="
let k=uint32(Console.ReadLine())
let rec forLoop i k=
    match i<=n with
    | false -> ()
    | true -> match i/k with
              | 0u -> printf " %i" i
                      forLoop (i+1u) (k-1u)
              | _ -> printf " %i" (i%k)
                     forLoop (i+1u) k
let res=forLoop 1u k
printfn ""