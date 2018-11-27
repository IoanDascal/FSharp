(*
    https://www.geeksforgeeks.org/interpolation-search/
        Interpolation Search
    Given a sorted array of n uniformly distributed values arr[], 
write a function to search for a particular element x in the array.
Linear Search finds the element in O(n) time, Jump Search takes O(√ n) 
time and Binary Search take O(Log n) time.
    The Interpolation Search is an improvement over Binary Search for 
instances, where the values in a sorted array are uniformly distributed. 
Binary Search always goes to the middle element to check. On the other hand, 
interpolation search may go to different locations according to the value of 
the key being searched. For example, if the value of the key is closer to 
the last element, interpolation search is likely to start search toward the
end side.
*)

open System
printf "Enter n="
let n=int(Console.ReadLine())
let a=[|for i in 1..n do 
            printf "a[%i]=" i
            yield(int(Console.ReadLine()) )|]
printfn "%A" a
printf "Enter element to search, key="
let key=int(Console.ReadLine())
let interpolationSearch (arr: int array) key=
    let rec find low high=
        match low<=high && key>=arr.[low] && key<=arr.[high] with
        | false -> None
        | true -> let pos=int((float low)+(float (high-low))/(float (arr.[high]-arr.[low]))*(float (key-arr.[low])))
                  match arr.[pos]=key with
                  | true -> Some pos
                  | false -> if arr.[pos]<key then
                                 find (pos+1) high
                             else
                                 find low (pos-1)
    find 0 (arr.Length-1)
let found=interpolationSearch a key
if found.IsSome then printfn "Found searched element in position=%i" found.Value
    else printfn "The searched element is not in array." 