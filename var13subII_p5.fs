(*
    Generate a matrix with n rows and n columns so that:
-  if j=n-i-1 then matrix[i][j]=0
-  if j<n-i-1 then matrix[i][j]=j+1
-  if j>n-i-1 then matrix[i][j]=n-i
*)
open System
printf " n="
let n=int(Console.ReadLine())
let (| Lower | Equal | Bigger |) (a, b)=
    match a<b with
    | true -> Lower
    | false -> match a=b with
               | true -> Equal
               | false -> Bigger  
let matrix=[|for i in 0..n-1 do
                  yield ([|for j in 0..n-1 do
                               match ((i+j), (n-1)) with
                               | Lower -> yield (j+1)
                               | Equal -> yield 0
                               | Bigger -> yield (n-i)|])|]

let res= matrix
for line in matrix do
    printfn "%A" line