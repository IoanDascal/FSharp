(*
    https://www.geeksforgeeks.org/merge-sort/
    https://www.coursera.org/lecture/algorithms-part1/mergesort-ARWDq
    https://stackoverflow.com/questions/35594171/merge-sort-for-f-sharp
*)

let x=[|3;6;9;13;25;36|]
let y=[|1;7;11;27|]
let merge (x:int array) (y:int array) =
    let rec mergeA x y cont=
        match (x,y) with
        | [||],b -> cont b
        | a,[||] -> cont a
        | a,b -> if a.[0]<b.[0] then 
                     mergeA a.[1..] b (fun r -> cont (Array.concat [[|a.[0]|];r]))
                 else
                     mergeA a b.[1..] (fun r -> cont (Array.concat [[|b.[0]|];r]))
    mergeA x y id
let res=merge x y

let rec mergeSort (x:int array)=
    let rec mergesort x cont=
        match x with
        | [||] -> cont [||]
        | [|a|] -> cont x
        | _ -> let mid=(Array.length x)/2
               mergesort x.[..mid] (fun y -> mergesort x.[mid..] (fun z -> cont (merge y z)))
    mergesort x id

// initialization function
let randFunc = 
  let rnd = (new System.Random(int System.DateTime.Now.Ticks)).Next
  rnd


let randomArray = Array.init 100000 randFunc
printfn "%A" randomArray
let resA=mergeSort randomArray
printfn "%A" resA
printfn "%d" resA.[(Array.length resA)-2]

//For lists
// create a random list 
let randomList = List.init 100000 randFunc
printfn "%A" randomList

let merge xs ys = 
    let rec mrg xs ys cont =
        match (xs, ys) with
        | ([], ys) -> cont ys
        | (xs, []) -> cont xs
        | (x::xs', y::ys') ->
            if x < y 
            then mrg xs' ys (fun rs -> cont (x::rs))
            else mrg xs ys' (fun rs -> cont (y::rs))
    mrg xs ys id
let mergeSort xs = 
    let rec msort xs cont = 
        match xs with
        | []    -> cont []
        | [x]   -> cont xs
        | _     -> 
            let mid = List.length xs / 2
            let (xs', xs'') = List.splitAt mid xs
            msort xs' (fun ys' -> msort xs'' (fun ys'' -> cont (merge ys' ys'')))
    msort xs id
let resS=mergeSort randomList
printfn "%A" resS
printfn "%d" resS.[(List.length resS)-2]