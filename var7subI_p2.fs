(*
 read n  ( natural number)
 nr <- 0 
┌ for a <- 9,0,-1 do
│  m <- n 
│┌ while m ≠ 0 and m%10 ≠ a do
││    m <- [m/10]    
│└■
│┌ if m ≠ 0 then
││   nr <- nr*10+m%10    
│└■
└■
 write nr 
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
let rec forLoop nr a=
    match a with 
    | 0 -> nr
    | _ -> let m=n
           let rec whileLoop x=
               printfn "m=%i" x
               match (x<>0) && (x%10<>a) with
               | true -> whileLoop (x/10)
               | false -> x
           let res=whileLoop m
           printfn "rezM=%i" res
           if res<>0 then forLoop (nr*10+res%10) (a-1)
               else forLoop nr (a-1)

let res=forLoop 0 9
printfn "%i" res
    
