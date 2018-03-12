(*
read a (natural number , a<1000000000)
┌ repeat
│   b <- 0  
│┌ while a!=0 do
││   b <- b+a%10 
││   a <- [a/10] 
│└■
│   a <- b 
└ until a<10 
write b 
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