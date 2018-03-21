(*
    File nrvar144.txt contains an integer number on each line.
    Print on each row five of them  and compute  how many numbers have the
    sum of digits  an even number.
*)
open System.IO
let rec sumOfDigits sum n=
    match n with
    | 0 -> sum
    | _ -> sumOfDigits (sum+n%10) (n/10)

let sr=new StreamReader("nrvar144.txt")
let rec res i nrEvenSum=
    if i%5=0 then printfn ""
    match sr.EndOfStream with
    | true -> nrEvenSum
    | false -> let x=int32(sr.ReadLine())
               printf "%i " x
               let sumDigits=sumOfDigits 0 x
               match sumDigits%2=0 with
               | true -> res (i+1) (nrEvenSum+1)
               | false -> res (i+1) nrEvenSum

let final=res 0 0
printfn "\n %i" final