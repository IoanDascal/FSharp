printf "Dati n="
let n=int(System.Console.ReadLine())
let rec calcul n m p c=
    match n>0 with
    | false -> m
    | true -> match c>0 with
              | true -> calcul (n/10) (m+(c-1)*p) (p*10) (n/10%10)
              | false -> calcul (n/10) (m+c*p) (p*10) (n/10%10)
let res=calcul n 0 1 (n%10)
