(*
    This method requires three memory arrays. These are:
- Source array(unsorted array) called  vector;
- Destination array (sorted array) called sortedArray;
- An array of numbers, countingArray ,with indexes 0..n-1, initially all zero.
      The elements of the unsorted array  vector are copied in the sorted array, 
sortedArray, in the proper position according to the values from the countingArray array.  
For each element of the array vector, the algorithm counts how many items are smaller. 
The number of items smaller than vector[0] is stored in countingArray[0].   
The number of items smaller than vector[1] is stored in countingArray[1]. 
The number of items smaller than vector[i] is stored in countingArray[i]. 
*)

open System
printf "Enter the number of elements from array, n="
let n=int(Console.ReadLine())
let vector=[|for i in 0..n-1 do
                 printf "vector[%d]=" i
                 yield(int(Console.ReadLine()))|]

printfn "The unsorted array is:%A" vector

let countingSort (vector:int array)=
    let countingArray=Array.map (fun x -> let countX=Array.countBy (fun y -> if y<x then "<" else ">=") vector
                                          if (fst countX.[0])=">=" then n-(snd countX.[0])
                                          else n-(snd countX.[1])) vector
    let sortedArray=Array.create n Int32.MinValue 
    Array.iter2 (fun x y -> Array.set sortedArray x y) countingArray vector
    Array.iteri (fun i x -> if x=Int32.MinValue then Array.set sortedArray i sortedArray.[i-1]) sortedArray
    sortedArray

let sortedArray=countingSort vector
printfn "The sorted array is: %A" sortedArray