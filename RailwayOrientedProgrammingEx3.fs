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
let n=a.Length
let step=int(sqrt (float n))
type Result<'TSuccess,'TFailure>=
    | Success of 'TSuccess
    | Failure of 'TFailure
let bind processFunc lastResult=
    match lastResult with
    | Success s -> processFunc s 
    | Failure f -> Failure f 
let switch processFunc lastResult=
    Success (processFunc lastResult)
let rec startIndex stIndex nStep=
        let index=min nStep (n-1)
        match a.[index]<key with
        | false -> Success stIndex
        | true -> match stIndex<n with
                  | false -> Failure (sprintf "Key not found.")
                  | true -> startIndex nStep (nStep+step)
let rec find index =
    match a.[fst index]=key with
    | true -> Success (fst index)
    | false -> match (fst index)=(snd index) with
               | true -> Failure (sprintf "Key not found.")
               | false -> find ((fst index)+1, (snd index))
let finalIndex n stIndex=
    let stopIndex=min (n-1) (stIndex+step)
    (stIndex,stopIndex)
let jumpSearch (arr: int array)=
    arr
    |> startIndex 0 step
    |> bind (switch (finalIndex n ))
    |> bind find
    |> printfn "%A"

let res= jumpSearch a