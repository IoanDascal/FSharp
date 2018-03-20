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
let res=
    let mutable i=0
    let mutable nrEvenSum=0
    use sr=new StreamReader("nrvar144.txt")
    while not sr.EndOfStream do
        let x=int(sr.ReadLine())
        i<-i+1
        let sumDigits=sumOfDigits 0 x
        if (sumDigits%2)=0 then nrEvenSum <- nrEvenSum+1
            else () 
        printf "%i " x
        if i%5=0 then printfn ""
    nrEvenSum

printfn "\n %i" res