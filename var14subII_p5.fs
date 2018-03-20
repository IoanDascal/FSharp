(*
    Given an integer nr >0, with n digits (n<=8), generate a matrix 
    with n rows and n columns. First column must contain the last digit,
    second column must contain last but one digit, etc.
    Example : If nr=1359 the matrix should be:
       | 9 5 3 1 |
       | 9 5 3 1 |
       | 9 5 3 1 |
       | 9 5 3 1 |
*)
printf " n="
let n=int(System.Console.ReadLine())
let s= string n
let line=[|for i in 0..s.Length-1 do
                yield (int(s.[s.Length-i-1])-48)|]
printfn "%A" line
printfn ""
let matrix=[|for i in 0..s.Length-1 do yield line|]
for line in matrix do
    printfn "%A" line