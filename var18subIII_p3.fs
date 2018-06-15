(*
    - Write a function to calculate the average of elements
from an array of real numbers. 
    - Write a function to calculate the number of elements fron 
an array of real numbers that are greater or equal than the average.
*)
open System
printf "Enter the number of elements n="
let n=int(Console.ReadLine())
let vector=[for i in 0..n-1 do yield (printf "v[%i]=" i
                                      float(Console.ReadLine()))]
let average=List.average vector
let greatherOrEqualThanAverage=List.countBy (fun x -> x>=average) vector
printfn "%A" greatherOrEqualThanAverage
let res=match fst greatherOrEqualThanAverage.[0] with
        | true -> snd greatherOrEqualThanAverage.[0]
        | false -> snd greatherOrEqualThanAverage.[1]

printfn "The number of elements that are greather or equal than average is =%i" res