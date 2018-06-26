(*
    a) Write a function that return how many 0 digits are at the end
of the n! (factorial).
    b) Using the function from a) write another function that return the 
lowest number n for which n! contains minimum k digits of zero at the end.
*)
open System
///  a)
printf "Enter n="

let n=int(Console.ReadLine())
let nz n=
    let rec factorial n acc=
        if n<=1I then acc 
            else
                factorial (n-1I) (n*acc)
    let fact=factorial n 1I
    let rec nrZero (fact:bigint) zero=
        match fact%10I<>0I with
        | true -> zero
        | _ -> nrZero (fact/10I) (zero+1)
    nrZero fact 0
let res=nz (bigint n)
printfn "The number of zero digits at the end of n! is=%i" res
///  b)
printf "Enter k="
let k=int(Console.ReadLine())

let lowestNumber k=
    let rec aproximation nr=
        let k1=nz nr
        match k1<k with
        | true -> aproximation (2I*nr)
        | false -> nr
    let aprox=aproximation 1I
    let nr=aprox/2I;
    let rec lowest nr=
        let k1=nz nr
        match k1=k with
        | true -> nr
        | false -> lowest (nr+1I)
    lowest nr
    

let b=lowestNumber k
printfn "The number n with minimum %i digits of zero at the end of n! is : %O" k b
printfn ""
