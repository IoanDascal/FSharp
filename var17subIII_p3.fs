(*
    Given a list of n integers, calculate how many numbers are in the range
    formed by the first and the last item from the list.
*)
open System
printf "n="
let n=int(Console.ReadLine())
let vector=[for i in 1..n do yield int(Console.ReadLine())]
let a=vector.[0]
let b=vector.[n-1]
let swap (x,y)=(y,x)
let interchange=if a>b then swap (a,b) else (a,b)
let low=fst interchange
let big=snd interchange
let nr=List.countBy (fun x -> x>=low && x<=big) vector
printfn "There are %i numbers between %i si %i." (snd nr.[0]) low big
