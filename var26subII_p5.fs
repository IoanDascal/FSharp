(*
    Given a matrix with n rows and n columns; print all elements that
are equal with the product of all other elements from their column. 
If such elements doesn't exist then print "No elements".
*)
open System
printf "Enter the number of rows and columns n="
let n=int(Console.ReadLine())
let matrix=[for i in 0..n-1 do
                 yield([for j in 0..n-1 do
                            yield (printf "mat[%i,%i]=" i j
                                   int(Console.ReadLine()))])]
printfn "%A" matrix
let rec productOnColumn product line column=
    if line=n then product
        else productOnColumn (product*matrix.[line].[column]) (line+1) column 
let products=[for i in 0..n-1 do
                 yield( productOnColumn 1 0 i)]
printfn "%A" products
let maximumOnColumn column=List.max [for i in 0..n-1 do
                                       yield(matrix.[i].[column])]
let maximumElements=[for i in 0..n-1 do
                        yield(maximumOnColumn i)]
printfn "%A" maximumElements
//       Method 1
let isEqualElement lst1 lst2=List.exists2 (fun el1 el2 -> (el1/el2)=el2) lst1 lst2
if not (isEqualElement products maximumElements) then printfn "No elements"
    else
        List.iter2 (fun x y -> if x/y=y then printf "%i " y) products maximumElements
        printfn "" 

//     Method 2
let rec intersection lst1 lst2 acc=
    match (lst1,lst2) with
    | [],[] -> acc
    | [],_ -> acc
    | _,[] -> acc
    | x::xs,y::ys -> match x/y=y with
                     | true -> intersection xs ys (y::acc)
                     | false -> intersection xs ys acc

let final=intersection products maximumElements []
if final.IsEmpty then printfn "No elements"
    else
        printfn "%A" final