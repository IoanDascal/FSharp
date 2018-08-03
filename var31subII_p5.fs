(*
    Write a function to insert in a list all words which have the same first and 
last letter from a sentence. Store the words in reverse order of their occurrence.
*)

open System
printf "Enter n="
let n=int(Console.ReadLine())
let listOfWords=List.rev [for i in 1..n do     
                              printf "Enter a wordt:" 
                              let word=Console.ReadLine()
                              if word.[0]=word.[word.Length-1] then yield(word)]

printfn "%A" listOfWords