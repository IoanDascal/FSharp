(*
    Given a number nr with n digits, generate a matrix with n+1 rows 
    and n+1 columns so that:
    - all leading diagonal elements are zero,
    - all elements that are on row one, above the leading diagonal and 
         all elements that are on column one, below the leading diagonal
         are equal to the digit from the ones place in number n,
    - all elements that are on row two, above the leading diagonal and 
         all elements that are on column two, below the leading diagonal
         are equal to the digit from the tens place in number n,
    - all elements that are on row three, above the leading diagonal and 
         all elements that are on column three, below the leading diagonal
         are equal to the digit from the hundreds place in number n,
    - all elements that are on row four, above the leading diagonal and 
         all elements that are on column for, below the leading diagonal
         are equal to the digit from the thousands place in number n,
    - and so on..
*)
open System
printf "nr="
let nr=Console.ReadLine()
let nrOfDigits=nr.Length
let matrix=[|for i in 0..nrOfDigits do
                  yield ([|for j in 0..nrOfDigits do
                               match i=j with
                               | true -> yield 0
                               | false -> match i<j with
                                          | true ->  yield (int(nr.[nrOfDigits-i-1])-48)
                                          | false -> yield (int(nr.[nrOfDigits-j-1])-48)
                          |])
             |]

for i in 0..nrOfDigits do
    for j in 0..nrOfDigits do
        printf "%i " matrix.[i].[j]
    printfn ""
