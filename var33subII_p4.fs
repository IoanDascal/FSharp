(*
    Create a matrix using next algorithm:
x=2;
for(j=1;j<=5;j++)
    for(i=1;i<=3;i++)
    { 
        a[j][i]=x;
        x=x+1;
    }

*)

//Version 1
let mutable x=2
let matrix1=[|for j in 1..5 do
                 yield[|for i in 1..3 do 
                            yield x
                            x <- x+1|]|]
for i in 0..4 do   
    for j in 0..2 do
        printf "%4d " matrix1.[i].[j]
    printfn ""

// Version 2

printfn ""
x <- 2
let matrix2=Array2D.zeroCreate<int> 6 4
for j in 1..5 do   
    for i in 1..3 do
        matrix2.[j,i] <- x
        x <- x+1

for i in 1..5 do   
    for j in 1..3 do
        printf "%4d " matrix2.[i,j]
    printfn ""