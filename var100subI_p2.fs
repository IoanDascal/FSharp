(*
citeste a (numar natural, a<1000000000)
┌ repeta
│   b <- 0  
│┌ cat timp a!=0 executa
││   b <- b+a%10 
││   a <- [a/10] 
│└■
│   a <- b 
└ pana_cand a<10 
scrie b 
*)


open System 
printf "Dati a="
let a=int32(Console.ReadLine())
let rec inner a b=
     match a=0 with
     | true -> b
     | false -> inner (a/10) (b+a%10)
let rec calcul a b=
    match a<10 with
    | true -> a
    | false -> calcul (inner a 0) b
let res=calcul a 0
printfn "%i" res