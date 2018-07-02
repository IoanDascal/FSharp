(*
    a. Write a function to calculate the maximum, minimum and
the average of an array of integer numbers.
    b. Write a function to calculate the average of an array of 
numbers without the minimum and maximum value, using the function 
from a.
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
let x=[for i in 1..n do
           yield (printf "x[%i]=" i
                  int(Console.ReadLine()))]
printfn "%A" x
let pRes=
    let p (x:int list)=
        let sum=List.sum x
        let maximum=List.max x
        let minimum=List.min x
        ((maximum,minimum),sum)
    p x
printfn "%A" pRes 
let average=floor(float((snd pRes)-(fst (fst pRes))-(snd (fst pRes)))/float(x.Length-2)*1000.0)
printfn "%.3f" (average/1000.0)

