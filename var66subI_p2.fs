(*
 n <- 0 
┌ repeat
│    read x  ( natural number)
│┌ if x≠0 then
││┌ if x%5=0 then
│││    n <- n+1 
│││ else
│││    n <- n-1  
││└■
│└■
└ until x=0 
┌ if n=0 then
│    write „YES” 
│ else 
│    write „NO”  
└■
*)

let rec repeatLoop n=
    printf "x="
    let x=int32(System.Console.ReadLine())
    match x<>0 with
    | true -> let n=if x%5=0 then (n+1) else (n-1)
              repeatLoop n  
    | false -> n   

let n=repeatLoop 0
if n=0 then
    printfn "YES"
    else
        printfn "NO"