(*
    If we consider the series: 1,  2,1,  3,2,1,  4,3,2,1,  ......
    the first group is 1, the second group is 2,1,  and the k'th group
    is: k,k-1,k-2,...,1. Determine the term n of the initial series.
*)
open System
printf "Dati n="
let n=int(Console.ReadLine())
let rec kGroup k acc=
    match acc<n with
    | false -> k-1
    | true -> kGroup (k+1) (acc+k)

let k= kGroup 1 0
printfn "k=%i" k
let numberOfElementsBeforeKGroup =(k*(k-1))/2
let positionOfTermNInGroupK=n-numberOfElementsBeforeKGroup
let nTerm=k-positionOfTermNInGroupK+1
printfn "%i" nTerm