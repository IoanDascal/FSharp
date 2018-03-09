printf "Dati a="
let a=int(System.Console.ReadLine())
printf "Dati b="
let b=int(System.Console.ReadLine())
let swap (a,b)=(b,a)
let res=if a>b then swap (a,b)
            else   
                (a,b)
let rec afis x y=
    match x<=y with
    | true -> printf "%i  " x
              afis (2*x) y   
    |false -> ()

let rez=afis (fst res) (snd res)
printfn ""