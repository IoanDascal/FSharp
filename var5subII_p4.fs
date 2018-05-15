(*
    Write a function to interchange letters from a string;
first letter with last, second letter with last but one, 
third letter with last but two, and so on.
Example : "asferv" ----->  "vrefsa"
*)

printf "Enter a string : "
let s=System.Console.ReadLine()
let str=s.ToCharArray()
let rec swapLetters i j (str:char array)=
    match i<j with
    | false -> str
    | true -> let aux =str.[i]
              str.[i] <- str.[j]
              str.[j] <- aux
              swapLetters (i+1) (j-1) str
let res=(swapLetters 0 (s.Length-1) str)
let res1=res |> System.String
printfn "%s" res1
