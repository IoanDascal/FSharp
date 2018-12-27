(*
    https://www.geeksforgeeks.org/merge-sort/
    https://www.coursera.org/lecture/algorithms-part1/mergesort-ARWDq
    https://stackoverflow.com/questions/35594171/merge-sort-for-f-sharp
*)

// For arrays
let mergeArray (x:int array) (y:int array) =
    let rec mergeA x y cont=
        match (x,y) with
        | [||],b -> cont b
        | a,[||] -> cont a
        | a,b -> if a.[0]<b.[0] then 
                     mergeA a.[1..] b (fun r -> cont (Array.concat [[|a.[0]|];r]))
                 else
                     mergeA a b.[1..] (fun r -> cont (Array.concat [[|b.[0]|];r]))
    mergeA x y id

let mergeSortArray (x:int array)=
    let rec mergesort x cont=
        match x with
        | [||] -> cont [||]
        | [|a|] -> cont x
        | _ -> let mid=(Array.length x)/2
               mergesort x.[..mid-1] (fun y -> mergesort x.[mid..] (fun z -> cont (merge y z)))
    mergesort x id

// initialization function
let randFunc = 
  let rnd = (new System.Random(int System.DateTime.Now.Ticks)).Next
  rnd


let randomArray = Array.init 100 randFunc
printfn "Unsorted array : %A" randomArray
let resA=mergeSortArray randomArray
printfn "Sorted array : %A" resA

//For lists
// create a random list 
let randomList = List.init 100 randFunc
printfn "Unsorted list : %A" randomList

let mergeList xs ys = 
    let rec mergeL xs ys cont =
        match (xs, ys) with
        | ([], ys) -> cont ys
        | (xs, []) -> cont xs
        | (x::xs', y::ys') ->
            if x < y 
            then mergeL xs' ys (fun rs -> cont (x::rs))
            else mergeL xs ys' (fun rs -> cont (y::rs))
    mergeL xs ys id
let mergeSortList xs = 
    let rec mergesort xs cont = 
        match xs with
        | []    -> cont []
        | [x]   -> cont xs
        | _     -> 
            let mid = List.length xs / 2
            let (xs', xs'') = List.splitAt mid xs
            mergesort xs' (fun ys' -> mergesort xs'' (fun ys'' -> cont (mergeList ys' ys'')))
    mergesort xs id
let resS=mergeSortList randomList
printfn "Sorted list : %A" resS