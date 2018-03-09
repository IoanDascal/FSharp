open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let nz n=
    let rec factorial n acc=
        if n<=1I then acc 
            else
                factorial (n-1I) (n*acc)
    let fact=factorial n 1I
    let rec nrzero (fact:bigint) zero=
        match fact%10I<>0I with
        | true -> zero
        | _ -> nrzero (fact/10I) (zero+1)
    nrzero fact 0
let res=nz (bigint n)
printfn "%i" res
printf "Dati k="
let k=int(System.Console.ReadLine())

let rec nrMinim k (nrMic:bigint)=
    let k1=nz nrMic
    match k1=k with
    | true -> nrMic
    | false -> nrMinim k (nrMic+1I) 

let b=nrMinim k 1I
printfn "Numarul este: %O" b
printfn ""
