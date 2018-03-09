printf "Dati a="
let a=int(System.Console.ReadLine())
printf "Dati n="
let n=int(System.Console.ReadLine())
let rec calcul a i j=
    match i<=n with
    | false -> a
    | true -> match i%2=0 with
              | true -> calcul (a-j) (i+1) (7-j)  
              | false -> calcul (a+j) (i+1) (7-j)

let res= calcul a 1 3
printfn "%i" res