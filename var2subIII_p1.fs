(*
    Using backtracking write a function that prints all words that
can be obtained with letters from set A={a,b,c,d,e}. 
Words must not have two consecutive vowels. Which is the last generated word ?
*)

printf "Enter number of letters from set A, n="
let n=int(System.Console.ReadLine())
printf "Enter number of letters from each word k="
let k=int(System.Console.ReadLine())
let solution=Array.zeroCreate<int> 10
let copySolution=Array.zeroCreate<int> 10
let validateSolution p=
    if p=1 then true
        else
            not ((solution.[p-1]=1 && solution.[p]=5) || (solution.[p-1]=5 && solution.[p]=1) || (solution.[p-1]=1 && solution.[p]=1) || (solution.[p-1]=5 && solution.[p]=5))
           
let printSolution (sol:int array) p=
    for j in 1..p do
        if sol.[j]=1 then printf "a"
        if sol.[j]=2 then printf "b"
        if sol.[j]=3 then printf "c"
        if sol.[j]=4 then printf "d"
        if sol.[j]=5 then printf "e"
    printfn ""
let isCompleteSolution p=
    p=k
let makeCopy (sol:int array)=
    for i in 0..9 do  
        copySolution.[i] <- sol.[i]
let rec backtracking p=
    for i in 1..n do
        solution.[p] <- i
        if validateSolution p then
            if isCompleteSolution p then
                printSolution solution p
                makeCopy solution
            else 
                backtracking (p+1)

let res=backtracking 1
printfn "The last generated word is : "
let res1=printSolution copySolution k