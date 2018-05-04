(*
    A natural number is said to be extra prime if the number and all
numbers obtained through the permutation of his digits are prime
numbers. For example 113 is extra prime because 113,311 and 131 are
prime numbers.
 - Write a function to compute the sum of exponents from the
 prime factorization of a natural number x.
 - Using the function above, write a function that verify if a 
 natural number is extra prime.
*)

let rec sumOfExponents x d s=
    match x>1 with
    | false -> s
    | true -> match x%d=0 with
              | false -> sumOfExponents x (d+1) s
              | true -> sumOfExponents (x/d) d (s+1)
let t1=sumOfExponents 7313 2 0
printfn "%i" t1
let isPrime n=
    (sumOfExponents n 2 0)=1
let t3=isPrime 7313
printfn "%b" t3
let permutation x=
    let lastDigit=x%10
    let rec digits n nr=
        match n>0 with  
        | false -> nr
        | true -> digits (n/10) (nr+1)
    let nrDigits=digits (x/10) 0
    let p=lastDigit*(pown 10 nrDigits)+x/10
    p

let t2=permutation 5113
printfn "%i" t2
let xInit=7313;

let listOfNumbers x=
    let p=permutation x
    let rec loop p listON=
        match x=p with   
        | true -> listON
        | false -> loop (permutation p) (p::listON)
    loop p [x]
      
let t4=listOfNumbers xInit
printfn "%A" t4
let extraPrime x=
    (listOfNumbers x) |> List.forall isPrime

let res=extraPrime 113
if res then printfn "YES" else printfn "NO"
    