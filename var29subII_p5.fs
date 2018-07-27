(*
    Given a matrix with n rows and n columns, an integer number x is 
called multiple if after multiplying of x with each element from the first 
column it can be obtained all elements from another column. Compute the 
product of all multiples from a matrix. 
Example: For matrix  2  7  4  8  4
                     1  1  2  4  2
                     3 12  6 12  3
                     1 22  2  4  2
                     5 10 10 20  8
the multiples are: 2 for columns 1 and 3
                   4 for columns 1 and 4
the product is : 2*4=8
*)

open System
printf "Enter the number of rows and columns n="
let n = int(Console.ReadLine())
let matrix=[|for i in 0..n-1 do 
                 yield([|for j in 0..n-1 do
                            yield(printf "matrix[%i,%i]=" i j
                                  int(Console.ReadLine()))|])|]
for row in matrix do
    printfn "%A" row
let rec multiplesProduct (column:int) (multiple:int)=
    match column<n with
    | false -> multiple
    | true -> let quotient=matrix.[0].[column]/matrix.[0].[0]
              let rec verify i=
                  if (i=n ||  matrix.[i].[column]/matrix.[i].[0]<>quotient) then i
                      else verify (i+1)
              printfn "%i" (verify 1)
              if (verify 1)=n then multiplesProduct (column+1) (multiple*quotient)
                  else multiplesProduct (column+1) multiple

let res=multiplesProduct 1 1
printfn "%i" res

