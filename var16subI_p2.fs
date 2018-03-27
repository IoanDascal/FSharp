(*
 read n ( natural munber not null)
┌ for i <- 1,n-1 do
│┌ if i%2=0 then
││    write ’#’
│└■
│┌ for j <- i+1,n do
││    write ’*’
│└■
└■
*)
open System
printf "Dati n="
let n=Console.ReadLine() |> int
let rec innerForLoop (j:int) n =
    if j<=n then
        printf "*"
        innerForLoop (j+1) n
    else ()       
   
let rec forLoop i n=
    if i<n then
        if i%2=0 then 
            printf "#" 
        innerForLoop (i+1) n 
        forLoop (i+1) n
    else ()
    
let res=forLoop 1 n
