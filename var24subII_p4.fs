(*
    Generate a matrix with n rows and n columns such that each row and
each column must contain all integer numbers from 1 to n.
*)

printf "Enter the number of rows and columns n="
let n=int(System.Console.ReadLine())
let A=[for i in 0..n-1 do 
           yield[for j in (i+1)..(n+i) do
                     yield(if j%n=0 then n else (j%n))]]
for line in A do  
    printfn "%A" line