(*
    Given an array with 3*n elements, write a function that interchange
the first even element from first n elements of the array with the last 
odd element from the last n elements of the array if both exists.
*)

open System
printf "Enter the number of elements  n="
let n=int32(Console.ReadLine())
let numbers=[|for i in 1..3*n do
                  yield(printf "numbers[%i]=" i
                        int32(Console.ReadLine()))|]
let swapElementsInArray (arr:int32 array) (i:int32) (j:int32)=
    let mutable aux = arr.[i]
    arr.[i] <- arr.[j]
    arr.[j] <- aux
    arr
let positionEven=Array.tryFindIndex (fun x -> x%2=0) numbers.[..n-1]
if positionEven.IsNone then printfn "%A" numbers 
    else
       let positionOdd=Array.tryFindIndexBack (fun x -> x%2=1) numbers
       if positionOdd.IsNone then printfn "%A " numbers 
           else if positionOdd.Value < 2*n then printfn "%A " numbers
                    else let newNumbers=swapElementsInArray numbers positionEven.Value positionOdd.Value
                         printfn "nn : %A" newNumbers