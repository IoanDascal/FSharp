(*
    https://www.geeksforgeeks.org/jump-search/
    Jump Search is a searching algorithm for sorted arrays. 
The basic idea is to check fewer elements (than linear search) by 
jumping ahead by fixed steps or skipping some elements in place of 
searching all elements.
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
let jumpSearch (a:int array) key=
    let n=a.Length
    let step=int(sqrt (float n))
    let rec startIndex stIndex nStep=
        let index=min nStep (n-1)
        match a.[index]<key with
        | false -> Some stIndex
        | true -> match stIndex<n with
                  | false -> None
                  | true -> startIndex nStep (nStep+step)
    let stIndex=startIndex 0 step
    if stIndex.IsSome then 
        let finalIndex=min (n-1) (stIndex.Value+step)
        let rec find index=
            match a.[index]=key with
            | true -> Some index
            | false -> match index=finalIndex with
                       | true -> None
                       | false -> find (index+1)
        let position=find stIndex.Value
        if position.IsSome then 
            Some position.Value
        else 
            None
    else
        None

let res=jumpSearch a key
if res.IsSome then printfn "Found searched element in position %i" res.Value
    else printfn "The searched element is not in array."


