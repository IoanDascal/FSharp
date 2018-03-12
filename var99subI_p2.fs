(*
read x   (înteger) 
┌ if x<0 then 
│    x <- -x 
└■
p <- 1 
┌ for i <- 1,x  do
│    p <- (p*4)%10 
└■
write p 
*)
printf "Dati un numar intreg x="
let x=int32(System.Console.ReadLine())
let absValue x=
    if x<0 then -x
        else x
let absVal=absValue x
let rec loop i p=
    match i<=absVal with
    | false -> p
    | true -> loop (i+1) (p*4)%10
let res=loop 1 1
printfn "%i" res

